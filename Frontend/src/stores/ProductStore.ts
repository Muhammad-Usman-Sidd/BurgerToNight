import { defineStore } from 'pinia';
import { useToast } from 'vue-toastification';
import ProductService from '../services/ProductService';
import { ProductGetDTO, ProductCreateDTO, ProductUpdateDTO } from '../models/ProductDtos';
import { APIResponse } from '../models/APIResult';
import { CategoryGetDTO } from '../models/CategoryDto';
import { useAuthStore } from './AuthStore';
import axios from 'axios';

const toast = useToast();
const API_URL = import.meta.env.VITE_API_URL;

export const useBurgerStore = defineStore('burger', {
  state: () => ({
    burgers: [] as ProductGetDTO[],
    cart: [] as { burger: ProductGetDTO, quantity: number }[],
    showSidebar: false,
    pastOrders: [] as ProductGetDTO[],
    totalItems: 0,
    pageIndex: 1,
    pageSize: 3,
    categories: [] as CategoryGetDTO[],
    currentBurger: {} as any,
  }),
  actions: {
    async fetchCategories() {
      try {
        const response: APIResponse<any> = await axios.get(`${API_URL}/CategoryAPI`);
        this.categories = response.data.Result;
      } catch (error) {
        toast.error('Error fetching categories');
      }
    },
    async addCategory(category: any) {
      const authStore = useAuthStore();
      try {
        await ProductService.createProduct(category as ProductCreateDTO, authStore.token);
        toast.success('Category added successfully');
        this.fetchCategories();
      } catch (error) {
        toast.error('Error adding category');
      }
    },
    async fetchBurgers(page = 1) {
      try {
        const response: APIResponse<any> = await ProductService.getAllProducts(page);
        this.burgers = response.Result.Products;
        this.totalItems = response.Result.TotalCount;
        this.pageIndex = page;
      } catch (error) {
        toast.error('Error fetching burgers');
      }
    },
    async fetchBurgerById(id: number) {
      try {
        const response: APIResponse<ProductGetDTO> = await ProductService.getProduct(id);
        this.currentBurger = response.Result;
      } catch (error) {
        toast.error('Error fetching burger by ID');
      }
    },
    async addBurger() {
      const authStore = useAuthStore();
      try {
        await ProductService.createProduct(this.currentBurger as ProductCreateDTO, authStore.token);
        this.resetCurrentBurger();
        toast.success('Burger added successfully');
        this.fetchBurgers(this.pageIndex);
      } catch (error) {
        toast.error('Error adding burger');
      }
    },
    async fetchPastOrders() {
      try {
        const response: APIResponse<ProductGetDTO[]> = await ProductService.getAllProducts(1);
        this.pastOrders = response.Result;
      } catch (error) {
        toast.error('Error fetching past orders');
      }
    },
    async updateBurger(id: number) {
      const authStore = useAuthStore();
      try {
        const updateBurgerDTO: ProductUpdateDTO = {
          Id: id,
          Name: this.currentBurger.Name || '',
          Description: this.currentBurger.Description || '',
          Price: this.currentBurger.Price || 0,
          PreparingTime: this.currentBurger.PreparingTime || '',
          BCategoryId: this.currentBurger.BCategoryId || null,
          Image: this.currentBurger.Image || '',
        };
        await ProductService.updateProduct(updateBurgerDTO, authStore.token);
        toast.success('Burger updated successfully');
        this.resetCurrentBurger();
        this.fetchBurgers(this.pageIndex);
      } catch (error) {
        toast.error('Error updating burger');
      }
    },
    async deleteBurger(id: number) {
      const authStore = useAuthStore();
      try {
        await ProductService.deleteProduct(id, authStore.token);
        this.burgers = this.burgers.filter(burger => burger.Id !== id);
        toast.success('Burger deleted successfully');
      } catch (error) {
        toast.error('Error deleting burger');
      }
    },
    handleImageUpload(event: Event) {
      try {
        const file = (event.target as HTMLInputElement).files[0];
        const reader = new FileReader();
        reader.onloadend = () => {
          this.currentBurger.Image = reader.result as string;
        };
        reader.readAsDataURL(file);
      } catch (error) {
        toast.error('Error uploading image');
      }
    },
    resetCurrentBurger() {
      this.currentBurger = {
        Name: '',
        Description: '',
        Price: 0,
        PreparingTime: '',
        BCategoryId: null,
        Image: '',
        Id: null,
      };
    },
    addToCart(burger: ProductGetDTO, quantity: number) {
      try {
        const existingItem = this.cart.find(u => u.burger.Id === burger.Id);
        if (existingItem) {
          existingItem.quantity += quantity;
        } else {
          this.cart.push({ burger, quantity });
        }
        toast.success('Burger added to cart');
      } catch (error) {
        toast.error('Error adding burger to cart');
      }
    },
    toggleSidebar() {
      this.showSidebar = !this.showSidebar;
    },
    removeItem(burger: ProductGetDTO) {
      this.cart = this.cart.filter(item => item.burger.Id !== burger.Id);
    },
    async checkout() {
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
  },
});

export default useBurgerStore;
