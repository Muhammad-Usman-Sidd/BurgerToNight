import { defineStore } from 'pinia';
import { useToast } from 'vue-toastification';
import { APIResponse } from '../models/APIResult';
import CategoryService from '../services/CategoryService';
import { CategoryCreateDTO, CategoryGetDTO } from '../models/CategoryDtos';
import { useAuthStore } from './AuthStore';

const toast = useToast();
export const useCategoryStore = defineStore('category', {
  state: () => ({
    categories:[] as CategoryGetDTO[],
    currentCategory : {} as any
  }),
  actions:{
    async fetchCategories() {
      try {
        const response: APIResponse<any> = await CategoryService.getAllCategories();
        this.categories = response.Result;
      } catch (error) {
        toast.error('Error fetching categories');
      }
    },
    async addCategory() {
      const authStore = useAuthStore();
      try {
        await CategoryService.createCategory(this.currentCategory, authStore.token);
        this.fetchCategories();
        toast.success('Category added successfully');
      } catch (error) {
        toast.error('Error adding category');
      }
    },
    async deleteBurger(id: number) {
      const authStore = useAuthStore();
      try {
        await CategoryService.deleteCategory(id, authStore.token);
        this.categories = this.categories.filter(u => u.Id !== id);
        toast.success('Burger deleted successfully');
      } catch (error) {
        toast.error('Error deleting burger');
      }
    },
  }
})
export default useCategoryStore;