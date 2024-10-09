import { createSlice, PayloadAction, createAsyncThunk } from "@reduxjs/toolkit";
import {
  ProductGetDTO,
  ProductCreateUpdateDTO,
} from "../../models/ProductDtos";
import { APIResponse } from "../../models/APIResult";
import { RootState } from "../store";
import productService from "../../services/ProductService";
import { toast } from "react-toastify";

interface ProductState {
  products: ProductGetDTO[];
  currentProduct: ProductCreateUpdateDTO | null;
  topProducts: ProductGetDTO[];
  deals: ProductGetDTO[];
  totalItems: number;
  pageIndex: number;
  pageSize: number;
  searchQuery: string;
  loading: boolean;
}

const initialState: ProductState = {
  products: [],
  currentProduct: null,
  topProducts: [],
  deals: [],
  totalItems: 0,
  pageIndex: 1,
  pageSize: 10,
  searchQuery: "",
  loading: false,
};

export const fetchProducts = createAsyncThunk<
  void,
  { pageIndex?: number; pageSize?: number; searchQuery?: string },
  { state: RootState }
>(
  "products/fetchAll",
  async ({ pageIndex, pageSize, searchQuery } = {}, { getState, dispatch }) => {
    const productstate = getState().product;

    const finalPageIndex = pageIndex ?? productstate.pageIndex;
    const finalPageSize = pageSize ?? productstate.pageSize;
    const finalSearchQuery = searchQuery ?? productstate.searchQuery;

    const response: APIResponse<any> = await productService.getAllProducts(
      finalPageIndex,
      finalPageSize,
      finalSearchQuery
    );

    if (response.IsSuccess) {
      dispatch(setProducts(response.Result.Products));
      dispatch(setTotalItems(response.Result.TotalCount));
    } else {
      toast.error(response.ErrorMessages.join(", "));
    }
  }
);

export const fetchDeals = createAsyncThunk<void, void, { state: RootState }>(
  "products/fetchDeals",
  async (_, { getState, dispatch }) => {
    const { pageIndex, pageSize } = getState().product;

    const response: APIResponse<any> = await productService.getAllProducts(
      pageIndex,
      pageSize,
      "Deals"
    );

    if (response.IsSuccess) {
      dispatch(setDeals(response.Result.Products));
    } else {
      toast.error(response.ErrorMessages.join(", "));
    }
  }
);

export const fetchProductById = createAsyncThunk<
  void,
  number,
  { state: RootState }
>("products/fetchById", async (id, { getState, dispatch }) => {
  const { isLoggedIn } = getState().auth;

  if (isLoggedIn) {
    const response: APIResponse<ProductGetDTO> =
      await productService.getProduct(id);

    if (response.IsSuccess) {
      dispatch(setCurrentProduct(response.Result));
    } else {
      toast.error(response.ErrorMessages.join(", "));
    }
  } else {
    toast.error("Please log in to access this feature");
  }
});

export const addProduct = createAsyncThunk<
  void,
  ProductCreateUpdateDTO,
  { state: RootState }
>("products/add", async (dto, { getState, dispatch }) => {
  const { isLoggedIn, role } = getState().auth;

  if (isLoggedIn && role === "admin") {
    try {
      const response = await productService.createProduct(dto);
      if (response.IsSuccess) {
        toast.success("Item added successfully");
        dispatch(fetchProducts({}));
      } else {
        toast.error(response.ErrorMessages.join(", "));
      }
    } catch (error) {
      toast.error(`Error adding product: ${error}`);
    }
  } else {
    toast.error("Not authorized");
  }
});

export const updateProduct = createAsyncThunk<
  void,
  ProductCreateUpdateDTO,
  { state: RootState }
>("products/update", async (dto, { getState, dispatch }) => {
  const { isLoggedIn, role } = getState().auth;

  if (isLoggedIn && role === "admin") {
    try {
      const response = await productService.updateProduct(dto);
      if (response.IsSuccess) {
        toast.success("Item updated successfully");
        dispatch(fetchProducts({}));
      } else {
        toast.error(response.ErrorMessages.join(", "));
      }
    } catch (error) {
      toast.error(`Error updating product: ${error}`);
    }
  } else {
    toast.error("Not authorized");
  }
});

export const deleteProduct = createAsyncThunk<
  void,
  number,
  { state: RootState }
>("products/deleteById", async (id, { getState, dispatch }) => {
  const { isLoggedIn, role } = getState().auth;

  if (isLoggedIn && role === "admin") {
    try {
      const response = await productService.deleteProduct(id);
      if (response.IsSuccess) {
        dispatch(fetchProducts({}));
        toast.success("Item deleted successfully");
      } else {
        toast.error(response.ErrorMessages.join(", "));
      }
    } catch (error) {
      toast.error(`Error deleting product: ${error}`);
    }
  } else {
    toast.error("Please log in to access this feature");
  }
});

export const fetchTopProducts = createAsyncThunk<
  void,
  number,
  { state: RootState }
>("products/fetchTopProducts", async (topCount, { dispatch }) => {
  try {
    const response: APIResponse<ProductGetDTO[]> =
      await productService.getTopProduct(topCount);
    console.log(response);
    if (response.IsSuccess) {
      dispatch(setTopProducts(response.Result));
    } else {
      toast.error(response.ErrorMessages.join(", "));
    }
  } catch (error) {
    toast.error(`Error:${error}`);
    console.error(error);
  }
});

const productSlice = createSlice({
  name: "products",
  initialState,
  reducers: {
    setProducts: (state, action: PayloadAction<ProductGetDTO[]>) => {
      state.products = action.payload;
    },
    setCurrentProduct: (state, action: PayloadAction<ProductGetDTO | null>) => {
      state.currentProduct = action.payload;
    },
    setDeals: (state, action: PayloadAction<ProductGetDTO[]>) => {
      state.deals = action.payload;
    },
    setTopProducts: (state, action: PayloadAction<ProductGetDTO[]>) => {
      state.topProducts = action.payload;
    },
    setTotalItems: (state, action: PayloadAction<number>) => {
      state.totalItems = action.payload;
    },
    setSearchQuery: (state, action: PayloadAction<string>) => {
      state.searchQuery = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(fetchProductById.pending, (state) => {
        state.loading = true;
      })
      .addCase(fetchProductById.fulfilled, (state) => {
        state.loading = false;
      });

    builder
      .addCase(fetchProducts.pending, (state) => {
        state.loading = true;
      })
      .addCase(fetchProducts.fulfilled, (state) => {
        state.loading = false;
      });
    builder
      .addCase(fetchDeals.pending, (state) => {
        state.loading = true;
      })
      .addCase(fetchDeals.fulfilled, (state) => {
        state.loading = false;
      });

    builder
      .addCase(fetchTopProducts.pending, (state) => {
        state.loading = true;
      })
      .addCase(fetchTopProducts.fulfilled, (state) => {
        state.loading = false;
      });
  },
});

export const {
  setProducts,
  setCurrentProduct,
  setDeals,
  setTopProducts,
  setTotalItems,
  setSearchQuery,
} = productSlice.actions;

export default productSlice.reducer;
