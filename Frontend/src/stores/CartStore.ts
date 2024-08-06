import { defineStore } from 'pinia';
import { useToast } from 'vue-toastification';
import { ProductGetDTO } from '../models/ProductDtos';
import { useAuthStore } from './AuthStore';
import OrderService from '../services/OrderService';
import { OrderCreateDTO, OrderGetDTO} from '../models/OrderDtos';
import Login from '../views/Auth/Login.vue';

const toast = useToast();
const orderService = new OrderService();

export const useCartStore = defineStore('cart', {
  state: () => ({
    cart: [] as { burger: ProductGetDTO; quantity: number }[],
    showSidebar: false,
    pastOrders: [] as OrderCreateDTO[],
    orderStatus: {} as Record<string, OrderGetDTO>,
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
            Items: this.cart.map((item) => ({
              ProductId: item.burger.Id,
              Quantity: item.quantity,
              Price: item.burger.Price,
            })),
          };
          const response = await orderService.createOrder(orderDto, authStore.token);
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
          const response = await orderService.getUserOrders(authStore.user.id, authStore.token);
          if (response.IsSuccess) {
            this.pastOrders = response.Result;
          } else {
            toast.error(response.ErrorMessages.join(', '));
          }
        } catch (error) {
          toast.error('Error loading past orders');
        }
      }
      else{
        toast.error('login To see past orders')
      }
    },
    async loadOrderStatus(orderId: string) {
      const authStore = useAuthStore();
      try {
        const response = await orderService.getOrderStatus(orderId, authStore.token);
        if (response.IsSuccess) {
          this.orderStatus[orderId] = response.Result;
        } else {
          toast.error(response.ErrorMessages.join(', '));
        }
      } catch (error) {
        toast.error('Error loading order status');
      }
    },
  },
});
