import { defineStore } from 'pinia';
import { useToast } from 'vue-toastification';
import { ProductGetDTO } from '../models/ProductDtos';
import { useAuthStore } from './AuthStore';
import OrderService from '../services/OrderService';
import { OrderGetDTO, OrderCreateDTO, OrderUpdateDTO } from '../models/OrderDtos';
import { OrderDetailCreateDTO } from '../models/OrderDetailDtos';
import { APIResponse } from '../models/APIResult';
import Swal from 'sweetalert2';

const toast = useToast();
const orderService = new OrderService();

export const useOrderStore = defineStore('order', {
  state: () => ({
    cart: [] as { product: ProductGetDTO; quantity: number }[],
    currentOrder: {
      UserId: '',
      Name: '',
      PhoneNumber: '',
      Address: '',
      Items: [] as any[],
      OrderTotal: 0
    },
    showSidebar: false,
    pastOrders: [] as OrderGetDTO[],
    updateStatus:{} as OrderUpdateDTO
  }),
  actions: {
    async readCurrentOrder() {
      const authStore = useAuthStore();
      await authStore.getUserById();
      if (authStore.isLoggedIn) {
        this.currentOrder.UserId = authStore.user.Id;
        this.currentOrder.Name = authStore.user.Name;
        this.currentOrder.PhoneNumber = authStore.user.PhoneNumber;
        this.currentOrder.Address = authStore.user.Address;
        this.currentOrder.Items = this.cart.map((item) => ({
          ProductId: item.product.Id,
          ProductName: item.product.Name,
          ProductImage: item.product.Image,
          Quantity: item.quantity,
          Price: item.product.Price,
        }));
        this.currentOrder.OrderTotal = this.cart.reduce((total, item) => total + item.product.Price * item.quantity, 0);
      }
    },
    addToCart(product: ProductGetDTO, quantity: number) {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn && authStore.role === 'customer') {
        try {
          const existingItem = this.cart.find((item) => item.product.Id === product.Id);
          if (existingItem) {
            existingItem.quantity += quantity;
          } else {
            this.cart.push({ product, quantity });
          }
          toast.success('Product added to cart');
        } catch (error) {
          toast.error('Error adding product to cart');
        }
      } else {
        toast.error('Please Login To Add Product');
      }
    },
    toggleSidebar() {
      this.showSidebar = !this.showSidebar;
    },
    removeItem(product: ProductGetDTO) {
      this.cart = this.cart.filter((item) => item.product.Id !== product.Id);
    },
    async checkout() {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn && this.currentOrder.Items.length > 0) {
        try {
          const response = await orderService.placeOrder(this.currentOrder);
          if (response.IsSuccess) {
            this.cart = [];
            this.currentOrder = {
              UserId: '',
              Name: '',
              PhoneNumber: '',
              Address: '',
              Items: [],
              OrderTotal: 0
            };
            this.toggleSidebar();
            await this.loadUserPastOrders();
            toast.success('Order placed successfully');
          }
        } catch (error) {
          toast.error('Error during checkout');
        }
      }
    },
    async loadUserPastOrders() {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn && authStore.role === 'customer') {
        try {
          const response: APIResponse<OrderGetDTO[]> = await orderService.getUserOrders(authStore.user.Id);
          if (response.IsSuccess) {
            this.pastOrders = response.Result;
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
    async loadOrders() {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn && authStore.role === "admin") {
        try {
          const response: APIResponse<OrderGetDTO[]> = await orderService.getAllOrders();
          if (response.IsSuccess) {
            this.pastOrders = response.Result;
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
    async updateOrder() {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn && authStore.role === "admin") {
        try {
          const response = await orderService.updateOrder(this.updateStatus);
          if (response.IsSuccess) {
            toast.success('Order status updated successfully');
            await this.loadOrders();
          } else {
            toast.error(response.ErrorMessages.join(', '));
          }
        } catch (error) {
          toast.error('Error updating order status');
        }
      } else {
        toast.error('Login to update order status');
      }
    },
    async deleteOrder(orderId: number) {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn && authStore.role === 'admin') {
        const result = await Swal.fire({
          title: 'Are you sure?',
          text: "You won't be able to revert this!",
          icon: 'warning',
          showCancelButton: true,
          confirmButtonColor: '#3085d6',
          cancelButtonColor: '#d33',
          confirmButtonText: 'Yes, delete it!'
        });

        if (result.isConfirmed) {
          try {
            const response = await orderService.deleteOrder(orderId);
            if (response.IsSuccess) {
              toast.success('Order deleted successfully');
              await this.loadOrders();
            } else {
              toast.error(response.ErrorMessages.join(', '));
            }
          } catch (error) {
            toast.error('Error deleting order');
          }
        }
      } else {
        toast.error('Admin can delete order');
      }
    },
  },
});
