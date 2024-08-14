import { defineStore } from 'pinia';
import { useToast } from 'vue-toastification';
import ProductService from '../services/ProductService';
import { ProductGetDTO, ProductCreateDTO, ProductUpdateDTO } from '../models/ProductDtos';
import { APIResponse } from '../models/APIResult';
import { useAuthStore } from './AuthStore';
import Swal from 'sweetalert2';
import { stringifyQuery, useRouter } from 'vue-router';

const toast = useToast();
export const useBurgerStore = defineStore('product', {
  state: () => ({
    burgers: [] as ProductGetDTO[],
    currentBurger: {} as any,
    totalItems: 0,
    pageIndex: 1,
    pageSize: 6,
    searchQuery: '',
  }),
  actions: {
    async fetchBurgers() {
      try {
        const response: APIResponse<any> = await ProductService.getAllProducts(this.pageIndex,this.pageSize,this.searchQuery);
        this.burgers = response.Result.Products;
        this.totalItems = response.Result.TotalCount;
      } catch (error) {
        console.log(`No burgers Found realted to Search :${this.searchQuery}`)
      }
    },
    async fetchBurgerById(id: number) {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn) {
        try {
          const response: APIResponse<ProductGetDTO> = await ProductService.getProduct(id);
          this.currentBurger = response.Result;
        } catch (error) {
          toast.error('Error fetching burger by ID');
        }
      }
      else{
        toast.error('Please login to access this feature');
      }
    },
    async addBurger() {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn && authStore.role==='admin') {
        try {
          console.log(this.currentBurger)
          await ProductService.createProduct(this.currentBurger);
          this.resetCurrentBurger();
          toast.success('Burger added successfully');
          this.fetchBurgers();
        } catch (error) {
          toast.error('Error adding burger');
        }
      }
      else{
        toast.error('Please login to access this feature');
      }
    },
    async updateBurger(id: number) {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn &&authStore.role==='admin') {
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
          await ProductService.updateProduct(updateBurgerDTO);
          toast.success('Burger updated successfully');
          this.resetCurrentBurger();
          this.fetchBurgers();
        } catch (error) {
          toast.error('Error updating burger');
        }
      }
      else{
        toast.error("You Don't have access")
      }
    },
    
    async deleteBurger(id: number) {
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
            await ProductService.deleteProduct(id);
            this.burgers = this.burgers.filter(burger => burger.Id !== id);
            toast.success('Burger deleted successfully');
          } catch (error) {
            toast.error('Error deleting burger');
          }
        }
      } else {
        toast.error("You don't have access");
      }
    },
    handleImageUpload(event: Event) {
      try {
        const files = (event.target as HTMLInputElement).files;
        if (files && files.length != null) {

          const file = files[0];
        const reader = new FileReader();
        reader.onloadend = () => {
            this.currentBurger.Image = reader.result as string;
        };
        reader.readAsDataURL(file);
      }}
      catch (error) {
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
