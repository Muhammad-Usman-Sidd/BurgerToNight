import { defineStore } from 'pinia';
import { useToast } from 'vue-toastification';
import ProductService from '../services/ProductService';
import { ProductGetDTO, ProductCreateDTO, ProductUpdateDTO } from '../models/ProductDtos';
import { APIResponse } from '../models/APIResult';
import axios from 'axios';
import { CategoryGetDTO } from '../models/CategoryDto';
import { ref } from 'vue';

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
    token: "",
    categories: [] as CategoryGetDTO[],
    currentBurger: {} as any,
  }),
  actions: {
    async fetchCategories() {
      try {
        const response :APIResponse<any> = await axios.get("http://192.168.15.41:7168/api/CategoryAPI"); 
        console.log(response.data.Result);
        this.categories = response.data.Result; // Adjust based on the actual response structure
        console.log(this.categories);
      } catch (error) {
        console.error('Error fetching categories', error);
        toast.error('Error fetching categories');
      }
    },
    async addCategory(category: any) {
      try {
        await ProductService.createProduct(category as ProductCreateDTO, this.token); // Cast to ProductCreateDTO if applicable
        toast.success('Category added successfully');
        this.fetchCategories();
      } catch (error) {
        console.error('Error adding category', error);
        toast.error('Error adding category');
      }
    },
    async fetchBurgers(page= 1) {
      try {
        const response: APIResponse<any> = await ProductService.getAllProducts(page );
        console.log(response);
        this.burgers = response.Result.Products;
        this.totalItems = response.Result.TotalCount; 
        this.pageIndex = page;
      } catch (error) {
        console.error('Error fetching burgers', error);
        toast.error('Error fetching burgers');
      }
    },
    async fetchBurgerById(id: number) {
      try {
        const response: APIResponse<ProductGetDTO> = await ProductService.getProduct(id);
        this.currentBurger = response.Result;
      } catch (error) {
        console.error('Error fetching burger by ID', error);
        toast.error('Error fetching burger by ID');
      }
    },
    async addBurger() {
      try {
        await ProductService.createProduct(this.currentBurger as ProductCreateDTO, this.token);
        this.resetCurrentBurger();
        toast.success('Burger added successfully');
        this.fetchBurgers(this.pageIndex);
      } catch (error) {
        console.error('Error adding burger', error);
        toast.error('Error adding burger');
      }
    },
    async fetchPastOrders() {
      try {
        const response: APIResponse<ProductGetDTO[]> = await ProductService.getAllProducts(1); // Adjust if needed
        this.pastOrders = response.Result;
        console.log(this.pastOrders);
      } catch (error) {
        console.error('Error fetching past orders', error);
        toast.error('Error fetching past orders');
      }
    },
    async updateBurger(id: number) {
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
        await ProductService.updateProduct(updateBurgerDTO, this.token);
        toast.success('Burger updated successfully');
        this.resetCurrentBurger();
        this.fetchBurgers(this.pageIndex);
      } catch (error) {
        console.error('Error updating burger', error);
        toast.error('Error updating burger');
      }
    },
    async deleteBurger(id: number) {
      try {
        await ProductService.deleteProduct(id, this.token);
        this.burgers = this.burgers.filter(burger => burger.Id !== id);
        toast.success('Burger deleted successfully');
      } catch (error) {
        console.error('Error deleting burger', error);
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
        console.error('Error uploading image', error);
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
        console.error('Error adding burger to cart', error);
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
        console.log('Cart Items:', cartItems); // Verify data structure here
        this.pastOrders.push(...this.cart.map(item => item.burger)); // Push burgers only
        this.cart = [];
        this.toggleSidebar();
        toast.success('Order placed successfully');
      } catch (error) {
        console.error('Error during checkout', error);
        toast.error('Error during checkout');
      }
    }
  },
});

export default {useBurgerStore}
