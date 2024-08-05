import { defineStore } from 'pinia';
import { useToast } from 'vue-toastification';
import { ProductGetDTO } from '../models/ProductDtos';
import { useAuthStore } from './AuthStore';

const toast = useToast();

export const useCartStore = defineStore('cart', {
  state: () => ({
    cart: [] as { burger: ProductGetDTO, quantity: number }[],
    showSidebar: false,
    pastOrders: [] as ProductGetDTO[],
  }),
  actions: {
    addToCart(burger: ProductGetDTO, quantity: number) {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn) {
        try {
          const existingItem = this.cart.find(item => item.burger.Id === burger.Id);
          if (existingItem) {
            existingItem.quantity += quantity;
          } else {
            this.cart.push({ burger, quantity });
          }
          toast.success('Burger added to cart');
        } catch (error) {
          toast.error('Error adding burger to cart');
        }
      }
      else{
        toast.error("Please Login To Add Burger")
      }
    },
    toggleSidebar() {
      this.showSidebar = !this.showSidebar;
    },
    removeItem(burger: ProductGetDTO) {
      this.cart = this.cart.filter(item => item.burger.Id !== burger.Id);
    },
    async checkout() {
      const authStore=useAuthStore();
      if (authStore.isLoggedIn) {
        try {
          const cartItems = this.cart.map(item => ({
            productId: item.burger.Id,
            quantity: item.quantity,
            price: item.burger.Price,
          }));
          this.pastOrders.push(...this.cart.map(item => item.burger));
          this.cart = [];
          this.toggleSidebar();
          toast.success('Order placed successfully');
        } catch (error) {
          toast.error('Error during checkout');
        }
      }
    }
  },
});

export default useCartStore;
