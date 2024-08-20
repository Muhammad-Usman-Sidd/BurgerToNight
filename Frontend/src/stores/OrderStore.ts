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
const orderService=new OrderService();

export const useOrderStore = defineStore('order', {
  state: () => ({
    cart: [] as { product: ProductGetDTO; quantity: number }[],
    showSidebar: false,
    pastOrders: [] as OrderGetDTO[],
  }),
  actions: {
    addToCart(product: ProductGetDTO, quantity: number) {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn &&authStore.role==='customer') {
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
      await authStore.getUserById();
      console.log(authStore.user)
      if (authStore.isLoggedIn) {
        try {
          const orderDto: OrderCreateDTO = {
            UserId:authStore.user.Id,
            OrderTotal: this.cart.reduce((total, item) => total + item.product.Price * item.quantity, 0),
            Name: authStore.user.Name,
            PhoneNumber:authStore.user.PhoneNumber,
            Address:authStore.user.Address,
            Items: this.cart.map((item) => ({
              ProductId: item.product.Id,
              Quantity: item.quantity,
              Price: item.product.Price,
            })) as OrderDetailCreateDTO[],
          };
          const response = await orderService.placeOrder(orderDto);
          console.log(response);
          if (response.IsSuccess) {
            this.cart = [];
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
      if (authStore.isLoggedIn && authStore.role==='customer') {
        try {
          console.log(authStore.user)
          const response :APIResponse<OrderGetDTO[]> = await orderService.getUserOrders(authStore.user.Id);
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
    async loadOrders() {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn && authStore.role === "admin") {
        try {
          const response :APIResponse<OrderGetDTO[]> = await orderService.getAllOrders();
          if (response.IsSuccess) {
            this.pastOrders = response.Result;
            console.log(response);
          } else{
            toast.error(response.ErrorMessages.join(', '));
          }
        } catch (error) {
          toast.error('Error loading past orders');
        }
      } else {
        toast.error('Login to see past orders');
      }
    },
    async updateOrder(dto: OrderUpdateDTO) {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn && authStore.role === "admin") {
        try {
          const response = await orderService.updateOrder(dto, );
          if (response.IsSuccess) {
            toast.success('Order status updated successfully');
            await this.loadOrders();
          } else {
            toast.error(response.ErrorMessages.join(', '));
          }
        } catch (error) {
          toast.error('Error updating order status');
        }
      }
      else{
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
            }
            else {
              toast.error(response.ErrorMessages.join(', '));
            }
          } 
          catch (error) {
            toast.error('Error deleting order');
          }
        }
      }
      else{
        toast.error('Admin can delete order');
      }
      
    },
  },
});
