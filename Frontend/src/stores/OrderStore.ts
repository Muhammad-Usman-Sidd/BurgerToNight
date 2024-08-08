import { defineStore } from 'pinia';
import { useToast } from 'vue-toastification';
import { ProductGetDTO } from '../models/ProductDtos';
import { useAuthStore } from './AuthStore';
import OrderService from '../services/OrderService';
import { OrderGetDTO, OrderCreateDTO, OrderUpdateDTO } from '../models/OrderDtos';
import { OrderDetailCreateDTO } from '../models/OrderDetailDtos';
import { APIResponse } from '../models/APIResult';

const toast = useToast();
const orderService=new OrderService();

export const useOrderStore = defineStore('order', {
  state: () => ({
    cart: [] as { burger: ProductGetDTO; quantity: number }[],
    showSidebar: false,
    pastOrders: [] as OrderGetDTO[],
  }),
  actions: {
    addToCart(burger: ProductGetDTO, quantity: number) {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn) {
        try {
          const existingItem = this.cart.find((item) => item.burger.Id === burger.Id);
          if (existingItem) {
            existingItem.quantity += quantity;
          } else {
            this.cart.push({ burger, quantity });
          }
          toast.success('Burger added to cart');
        } catch (error) {
          toast.error('Error adding burger to cart');
        }
      } else {
        toast.error('Please Login To Add Burger');
      }
    },
    toggleSidebar() {
      this.showSidebar = !this.showSidebar;
    },
    removeItem(burger: ProductGetDTO) {
      this.cart = this.cart.filter((item) => item.burger.Id !== burger.Id);
    },
    async checkout() {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn) {
        try {
          const orderDto: OrderCreateDTO = {
            UserId: authStore.user.id,
            OrderTotal: this.cart.reduce((total, item) => total + item.burger.Price * item.quantity, 0),
            Name: authStore.user.name,
            PhoneNumber:authStore.user.phoneNumber,
            Address:authStore.user.address,
            Items: this.cart.map((item) => ({
              ProductId: item.burger.Id,
              Quantity: item.quantity,
              Price: item.burger.Price,
            })) as OrderDetailCreateDTO[],
          };
          const response = await orderService.placeOrder(orderDto, authStore.token);
          console.log(response);
          if (response.IsSuccess) {
            this.cart = [];
            this.toggleSidebar();
            await this.loadPastOrders();
            toast.success('Order placed successfully');
          } else {
            toast.error(response.ErrorMessages.join(', '));
          }
        } catch (error) {
          toast.error('Error during checkout');
        }
      }
    },
    async loadPastOrders() {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn) {
        try {
          const response :APIResponse<OrderGetDTO[]> = await orderService.getUserOrders(authStore.user.id, authStore.token);
          if (response.IsSuccess) {
            this.pastOrders = response.Result;
            console.log(response);
          } else {
            toast.error(response.ErrorMessages.join(', '));
          }
        } catch (error) {
          toast.error('Error loading past orders');
        }
      } else {
        toast.error('Login to see past orders');
      }
    },
    async updateOrderStatus(orderId: number, dto: OrderUpdateDTO) {
      const authStore = useAuthStore();
      try {
        dto.Id=orderId;
        const response = await orderService.updateOrder(dto, authStore.token);
        if (response.IsSuccess) {
          toast.success('Order status updated successfully');
          await this.loadPastOrders();
        } else {
          toast.error(response.ErrorMessages.join(', '));
        }
      } catch (error) {
        toast.error('Error updating order status');
      }
    },
    async deleteOrder(orderId: number) {
      const authStore = useAuthStore();
      try {
        const response = await orderService.deleteOrder(orderId, authStore.token);
        if (response.IsSuccess) {
          toast.success('Order deleted successfully');
          await this.loadPastOrders();
        } else {
          toast.error(response.ErrorMessages.join(', '));
        }
      } catch (error) {
        toast.error('Error deleting order');
      }
    },
  },
});
