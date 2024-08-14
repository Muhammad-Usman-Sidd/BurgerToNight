import { defineStore } from 'pinia';
import { useToast } from 'vue-toastification';
import { APIResponse } from '../models/APIResult';
import CategoryService from '../services/CategoryService';
import { CategoryCreateDTO, CategoryGetDTO } from '../models/CategoryDtos';
import { useAuthStore } from './AuthStore';
import Login from '../views/Auth/Login.vue';

const toast = useToast();
export const useCategoryStore = defineStore('category', {
  state: () => ({
    categories:[] as CategoryGetDTO[],
    currentCategory : {} as any
  }),
  actions:{
    async fetchCategories() {
      const authStore=useAuthStore()
      if (authStore.isLoggedIn) {
        try {
          const response: APIResponse<any> = await CategoryService.getAllCategories();
          this.categories = response.Result;
        } catch (error) {
          toast.error('Error fetching categories');
        }        
      }
      else{
        toast.error('You must be logged in to view categories');
      }

    },
    async addCategory() {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn &&authStore.role==='admin') {
        try {
          await CategoryService.createCategory(this.currentCategory,);
          this.fetchCategories();
          toast.success('Category added successfully');
        } catch (error) {
          toast.error('Error adding category');
        }
      }
      else{
        toast.error('You must be logged in to add a category');
      }
    },

     
    async deleteCategory(id: number) {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn && authStore.role==='admin') {
        try {
          await CategoryService.deleteCategory(id);
          this.categories = this.categories.filter(u => u.Id !== id);
          toast.success('Burger deleted successfully');
        } catch (error) {
          toast.error('Error deleting burger');
        }
      }
      else{
        toast.error('You must be logged in to delete a burger');
      }
    }
  }
})
export default useCategoryStore;