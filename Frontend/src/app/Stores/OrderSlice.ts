import { createSlice, PayloadAction, createAsyncThunk } from "@reduxjs/toolkit";
import { ProductGetDTO } from "../../models/ProductDtos";
import { OrderGetDTO, OrderUpdateDTO } from "../../models/OrderDtos";
import { APIResponse } from "../../models/APIResult";
import { RootState, AppDispatch } from "../store";
import OrderService from "../../services/OrderService";
import { toast } from "react-toastify";

interface CartItem {
  product: ProductGetDTO;
  quantity: number;
}

interface OrderState {
  cart: CartItem[];
  currentOrder: {
    UserId: string;
    Name: string;
    PhoneNumber?: string;
    Address?: string;
    Items: any[];
    OrderTotal: number;
  };
  showSidebar: boolean;
  pastOrders: OrderGetDTO[];
  orders: OrderGetDTO[];
  updateStatus: OrderUpdateDTO;
  orderLoading: boolean;
}

const initialState: OrderState = {
  cart: [],
  currentOrder: {
    UserId: "",
    Name: "",
    PhoneNumber: "",
    Address: "",
    Items: [],
    OrderTotal: 0,
  },
  orders: [],
  showSidebar: false,
  pastOrders: [],
  updateStatus: {} as OrderUpdateDTO,
  orderLoading: false,
};

const orderService = new OrderService();

export const readCurrentOrder = createAsyncThunk<
  void,
  void,
  { state: RootState; dispatch: AppDispatch }
>("order/readCurrentOrder", async (_, { getState, dispatch }) => {
  const { isLoggedIn, user } = getState().auth;
  if (isLoggedIn && user) {
    const cart = getState().order.cart;
    if (!user.Name || !user.PhoneNumber || !user.Address) {
      throw new Error("User information is incomplete");
    }

    const currentOrder = {
      UserId: user.Id,
      Name: user.Name,
      PhoneNumber: user.PhoneNumber,
      Address: user.Address,
      Items: cart.map((item) => ({
        ProductId: item.product.Id,
        ProductName: item.product.Name,
        ProductImage: item.product.Image,
        Quantity: item.quantity,
        Price: item.product.Price,
      })),
      OrderTotal: cart.reduce(
        (total, item) => total + item.product.Price * item.quantity,
        0
      ),
    };

    dispatch(setCurrentOrder(currentOrder));
  }
});

export const checkout = createAsyncThunk<
  void,
  void,
  { state: RootState; dispatch: AppDispatch }
>("order/checkout", async (_, { getState, dispatch }) => {
  const { isLoggedIn, role } = getState().auth;
  const currentOrder = getState().order.currentOrder;
  if (isLoggedIn && role === "customer") {
    try {
      const response = await orderService.placeOrder(currentOrder);
      dispatch(clearCart());
      if (response.IsSuccess) {
        await dispatch(fetchUserPastOrders());
      }
      toast.success("Order placed successfully");
    } catch (error) {
      toast.error(`Error : ${error}`);
    }
  } else {
    toast.error("Please login to proceed");
  }
});

export const updateOrder = createAsyncThunk<
  void,
  OrderUpdateDTO,
  { state: RootState }
>("order/updateOrder", async (updatedOrder, { getState, dispatch }) => {
  const { isLoggedIn, role } = getState().auth;
  if (isLoggedIn && role === "admin") {
    try {
      const response = await orderService.updateOrder(updatedOrder);
      if (response.IsSuccess) {
        dispatch(fetchOrders());
        toast.success("Order updated successfully");
      }
    } catch (error) {
      toast.error(`Error updating order: ${error}`);
    }
  } else {
    toast.error("Not Authorized!");
  }
});

export const fetchUserPastOrders = createAsyncThunk<
  void,
  void,
  { state: RootState }
>("order/fetchUserPastOrders", async (_, { getState, dispatch }) => {
  const { isLoggedIn, role, user } = getState().auth;
  if (isLoggedIn && role === "customer" && user) {
    try {
      const response: APIResponse<OrderGetDTO[]> =
        await orderService.getUserOrders(user.Id);
      if (response.IsSuccess) {
        dispatch(setPastOrders(response.Result));
      } else {
        toast.error(response.ErrorMessages.join(", "));
      }
    } catch (error) {
      toast.error(`Error : ${error}`);
    }
  } else if (role === "admin") {
    toast.error("You are Admin!");
  }
});

export const fetchOrders = createAsyncThunk<void, void, { state: RootState }>(
  "order/fetchOrders",
  async (_, { getState, dispatch }) => {
    const { isLoggedIn, role } = getState().auth;
    if (isLoggedIn && role === "admin") {
      try {
        const response: APIResponse<OrderGetDTO[]> =
          await orderService.getAllOrders();
        if (response.IsSuccess) {
          dispatch(setOrders(response.Result));
        } else {
          toast.error(response.ErrorMessages.join(", "));
        }
      } catch (error) {
        toast.error(`Error : ${error}`);
      }
    }
  }
);

export const deleteOrder = createAsyncThunk<void, number, { state: RootState }>(
  "order/deleteOrders",
  async (id, { getState, dispatch }) => {
    const { isLoggedIn, role } = getState().auth;
    if (isLoggedIn && role === "admin") {
      try {
        await orderService.deleteOrder(id);
        await dispatch(fetchOrders());
        toast.success("Item deleted successfully!");
      } catch (error) {
        throw new Error(`Error deleting order: ${error}`);
      }
    } else {
      throw new Error("Please login to access this feature");
    }
  }
);

const orderSlice = createSlice({
  name: "order",
  initialState,
  reducers: {
    addToCart: (
      state,
      action: PayloadAction<{ product: ProductGetDTO; quantity: number }>
    ) => {
      const { product, quantity } = action.payload;
      const existingItem = state.cart.find(
        (item) => item.product.Id === product.Id
      );
      if (existingItem) {
        existingItem.quantity += quantity;
      } else {
        state.cart.push({ product, quantity });
      }
      toast.success("Item added to cart");
    },
    removeItem: (state, action: PayloadAction<ProductGetDTO>) => {
      state.cart = state.cart.filter(
        (item) => item.product.Id !== action.payload.Id
      );
    },
    toggleSidebar: (state) => {
      state.showSidebar = !state.showSidebar;
    },
    setCurrentOrder: (state, action) => {
      state.currentOrder = action.payload;
    },
    clearCart: (state) => {
      state.cart = [];
      state.currentOrder.Items = [];
    },
    setPastOrders: (state, action: PayloadAction<OrderGetDTO[]>) => {
      state.pastOrders = action.payload;
    },
    setOrders: (state, action: PayloadAction<OrderGetDTO[]>) => {
      state.orders = action.payload;
    },
  },

  extraReducers: (builder) => {
    builder
      .addCase(fetchOrders.pending, (state) => {
        state.orderLoading = true;
      })
      .addCase(fetchOrders.fulfilled, (state) => {
        state.orderLoading = false;
      });

    builder
      .addCase(fetchUserPastOrders.pending, (state) => {
        state.orderLoading = true;
      })
      .addCase(fetchUserPastOrders.fulfilled, (state) => {
        state.orderLoading = false;
      });

    builder
      .addCase(readCurrentOrder.pending, (state) => {
        state.orderLoading = true;
      })
      .addCase(readCurrentOrder.fulfilled, (state) => {
        state.orderLoading = false;
      });
  },
});

export const {
  addToCart,
  removeItem,
  toggleSidebar,
  setCurrentOrder,
  clearCart,
  setPastOrders,
  setOrders,
} = orderSlice.actions;

export default orderSlice.reducer;
