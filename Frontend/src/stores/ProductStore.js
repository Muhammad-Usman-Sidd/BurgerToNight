import { defineStore } from 'pinia';
import axios from 'axios';
import { useToast } from 'vue-toastification';


const toast = useToast();

export const useBurgerStore = defineStore('burger', {
  state: () => ({
    burgers: [],
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
    async fetchBurgerById(id) {
      try {
        const response = await axios.get(`http://192.168.15.26:7168/api/ProductAPI/${id}`);
        this.burger = response.data.Result;
        Object.assign(this.currentBurger,response.data.Result)
      } catch (error) {
        console.error('Error fetching burger by id:', error);
      }
    },
    
    async fetchCategories() {
      try {
        const response = await axios.get(' http://192.168.15.26:7168/api/CategoryAPI');
        this.categories = response.data.Result;
      } catch (error) {
        console.error("Error fetching categories", error);
      }
    },
    async update() {
      try {
        console.log("Updating burger with data:", this.currentBurger); // Debugging log
        const response = await axios.put(
          `http://192.168.15.26:7168/api/ProductAPI/${this.currentBurger.Id}`,
          this.currentBurger,
          {
            headers: {
              'Content-Type': 'application/json',
            },
          }
        );
        this.resetCurrentBurger();
        console.log("Response from server:", response.data); // Debugging log
      } catch (error) {
        console.error("Error occured During update", error);
        toast.error("Error updating Burger")
      }
    },
    handleImageUpload(event) {
      const file = event.target.files[0];
      const reader = new FileReader();
      reader.onloadend = () => {
        this.currentBurger.Image = reader.result;
      };
      reader.readAsDataURL(file);
    }
  },
});
