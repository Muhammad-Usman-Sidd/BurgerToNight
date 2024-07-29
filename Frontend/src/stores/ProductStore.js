import { defineStore } from 'pinia';
import axios from 'axios';
import { useToast } from 'vue-toastification';
const toast = useToast();

export const useBurgerStore = defineStore('burger', {
  state: () => ({
    apiUrl: import.meta.env.VITE_API_URL,
    burgers: [],
    cart: [],
    showSidebar: false,
    pastOrders: [],
    totalItems: 0,
    pageIndex: 1,
    pageSize: 3,
    categories: [],
    currentBurger: {
      Name: '',
      Description: '',
      Price: 0,
      PreparingTime: '',
      BCategoryId: null,
      burgerCategory: '',
      Image: '',
      Id: null
    },
  }),
  actions: {
    async fetchCategories() {
      try {
        const response = await axios.get(`${this.apiUrl}/CategoryAPI`);
        this.categories = response.data.Result;
      } catch (error) {
        console.error("Error fetching categories", error);
        toast.error("Error fetching categories");
      }
    },
    async addCategory(category) {
      try {
        await axios.post(`${this.apiUrl}/CategoryAPI`, category);
        router.push("/categories");
      } catch (error) {
        console.error("Error Adding the Category", error);
        toast.error("Error adding category");
      }
    },
    async fetchBurgers(page = 1) {
      try {
        const response = await axios.get(`${this.apiUrl}/ProductAPI?pageNumber=${page}&pageSize=${this.pageSize}`);
        this.burgers = response.data.Result.Products;
        this.totalItems = response.data.Result.TotalCount;
        this.pageIndex = page;
      } catch (error) {
        console.error('Error fetching burgers:', error);
        toast.error("Error fetching burgers");
      }
    },
    async fetchBurgerById(id) {
      try {
        const response = await axios.get(`${this.apiUrl}/ProductAPI/${id}`);
        this.currentBurger = response.data.Result;
      } catch (error) {
        console.error('Error fetching burger with Id:', error);
        toast.error("Error fetching burger by Id");
      }
    },
    async addBurger() {
      try {
        await axios.post(`${this.apiUrl}/ProductAPI`, this.currentBurger);
        toast.success("Burger added successfully");
        this.resetCurrentBurger();
      } catch (error) {
        console.error("Error Adding the Burger", error);
        toast.error("Error adding burger");
      }
    },
    async fetchPastOrders() {
      try {
        const response = await axios.get(`${this.apiUrl}/PastOrders`);
        this.pastOrders = response.data.Result;
        console.log(this.pastOrders);
      } catch (error) {
        console.error("Error Fetching the Past Orders", error);
        toast.error("Error fetching past orders");
      }
    },
    async updateBurger() {
      try {
        await axios.put(
          `${this.apiUrl}/ProductAPI/${this.currentBurger.Id}`,
          this.currentBurger,
          {
            headers: {
              'Content-Type': 'application/json',
            },
          }
        );
        toast.success("Burger updated successfully");

        this.resetCurrentBurger();
      } catch (error) {
        console.error("Error occurred during update", error);
        toast.error("Error updating burger");
      }
    },
    async deleteBurger(id) {
      try {
        await axios.delete(`${this.apiUrl}/ProductAPI/${id}`);
        this.burgers = this.burgers.filter(burger => burger.Id !== id);
        toast.success("Burger deleted successfully");
      } catch (error) {
        console.error("Error occurred during deletion", error);
        toast.error("Error deleting burger");
      }
    },
    handleImageUpload(event) {
      try {
        const file = event.target.files[0];
        const reader = new FileReader();
        reader.onloadend = () => {
          this.currentBurger.Image = reader.result;
        };
        reader.readAsDataURL(file);
      } catch (error) {
        console.error("Error occurred during image upload", error);
        toast.error("Error uploading image");
      }
    },
    resetCurrentBurger() {
      this.currentBurger = {
        Name: '',
        Description: '',
        Price: 0,
        PreparingTime: '',
        BCategoryId: null,
        BurgerCategory: '',
        Image: '',
        Id: null
      };
    },
    addToCart(burger, quantity) {
      try {
        const existingItem = this.cart.find(item => item.burger.Id === burger.Id);
        if (existingItem) {
          existingItem.quantity += quantity;
        } else {
          this.cart.push({ burger, quantity });
        }
        toast.success("Burger added to cart");
      } catch (error) {
        console.error("Error adding burger to cart", error);
        toast.error("Error adding burger to cart");
      }
    },
    toggleSidebar() {
      this.showSidebar = !this.showSidebar;
    },
    removeItem(burger) {
      this.cart = this.cart.filter(item => item.burger.Id !== burger.Id);
    },
    async checkout() {
      try {
        const cartItems = this.cart.map(item => ({
          ProductId: item.burger.Id,
          Quantity: item.quantity,
          Price: item.burger.Price
        }));
        console.log('Cart Items:', cartItems); // Verify data structure here
        await axios.post(`${this.apiUrl}/Checkout`, cartItems);
        this.pastOrders.push(...this.cart);
        this.cart = [];
        this.toggleSidebar();
        toast.success("Order placed successfully");
      } catch (error) {
        console.error('Error during checkout:', error);
        toast.error("Error during checkout");
      }
    }
  },
});
