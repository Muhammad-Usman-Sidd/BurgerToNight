import { defineStore } from 'pinia';
import { useToast } from 'vue-toastification';
import ProductService from '../services/ProductService';
import { ProductGetDTO, ProductCreateDTO, ProductUpdateDTO } from '../models/ProductDtos';
import { APIResponse } from '../models/APIResult';
import { useAuthStore } from './AuthStore';

const toast = useToast();
export const useBurgerStore = defineStore('product', {
  state: () => ({
    burgers: [] as ProductGetDTO[],
    currentBurger: {} as any,
    totalItems: 0,
    pageIndex: 1,
    pageSize: 3,
  }),
  actions: {
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
    }
  },
});

export default useBurgerStore;
