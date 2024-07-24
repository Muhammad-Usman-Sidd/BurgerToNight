import { defineStore } from 'pinia';
import axios from 'axios';
import { useToast } from 'vue-toastification';

const toast = useToast();

export const useBurgerStore = defineStore('burger', {
  state: () => ({
    burgers: [],
    cart:{},
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
      BurgerCategory: '',
      Image: '',
      Id: null
    },
  }),
  actions: {
    async fetchBurgers(page = 1) {
      try {
        const response = await axios.get(`http://192.168.15.38:7168/api/ProductAPI?pageNumber=${page}&pageSize=${this.pageSize}`);
        this.burgers = response.data.Result.Products;
        this.totalItems = response.data.Result.TotalCount;
        this.pageIndex = page;
        console.log(this.burgers);
      } catch (error) {
        console.error('Error fetching burgers:', error);
        toast.error("Error fetching burgers");
      }
    },
    async fetchBurgerById(id){
      try {
        const response= await axios.get(`http://192.168.15.38:7168/api/ProductAPI/${id}`)
        this.currentBurger=response.data.Result;
        console.log(this.currentBurger);
      } catch (error) {
        console.error('Error fetching burger with Id:', error);
        toast.error("Error fetching burger By Id");
      }
    },
    async fetchCategories() {
      try {
        const response = await axios.get('http://192.168.15.38:7168/api/CategoryAPI');
        this.categories = response.data.Result;
      } catch (error) {
        console.error("Error fetching categories", error);
      }
    },
    async update() {
      try {
        console.log("Updating burger with data:", this.currentBurger);
        const response = await axios.put(
          `http://192.168.15.38:7168/api/ProductAPI/${this.currentBurger.Id}`,
          this.currentBurger,
          {
            headers: {
              'Content-Type': 'application/json',
            },
          }
        );
        this.resetCurrentBurger();
        console.log("Response from server:", response.data);
      } catch (error) {
        console.error("Error occurred during update", error);
        toast.error("Error updating Burger");
      }
    },
    async deleteBurger(id) {
      try {
        await axios.delete(`http://192.168.15.38:7168/api/ProductAPI/${id}`);
        this.burgers = this.burgers.filter(burger => burger.Id !== id);
        toast.success("Burger deleted successfully");
      } catch (error) {
        console.error("Error occurred during deletion", error);
        toast.error("Error deleting Burger");
      }
    },
    handleImageUpload(event) {
      const file = event.target.files[0];
      const reader = new FileReader();
      reader.onloadend = () => {
        this.currentBurger.Image = reader.result;
      };
      reader.readAsDataURL(file);
    },
    resetCurrentBurger(){
      this.currentBurger={
        Name: '',
        Description: '',
        Price: 0,
        PreparingTime: '',
        BCategoryId: null,
        BurgerCategory: '',
        Image: '',
        Id: null
      }
    },
    addToCart(name, quantity) {
      if(!this.cart[name]) this.cart[name] = 0;
      this.cart[name] += quantity;
    },
    toggleSidebar() {
        this.showSidebar = !this.showSidebar;
    },
  },
});
