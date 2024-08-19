import { defineStore } from 'pinia';
import { useToast } from 'vue-toastification';
import { APIResponse } from '../models/APIResult';
import CategoryService from '../services/CategoryService';
import { CategoryCreateDTO, CategoryGetDTO, CategoryUpdateDTO } from '../models/CategoryDtos';
import { useAuthStore } from './AuthStore';
import Swal from 'sweetalert2';

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
          await CategoryService.createCategory(this.currentCategory);
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
            await CategoryService.deleteCategory(id);
            this.categories = this.categories.filter(u => u.Id !== id);
            toast.success('Product deleted successfully');
          } catch (error) {
            toast.error('Error deleting product');
          }
        }
      } else {
        toast.error("You don't have access");
      }
    },
    async fetchCategoryById(id: number) {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn) {
        try {
          const response: APIResponse<CategoryGetDTO> = await CategoryService.getCategory(id);
          this.currentCategory = response.Result;
        } catch (error) {
          toast.error('Error fetching product by ID');
        }
      }
      else{
        toast.error('Please login to access this feature');
      }
    },
    async updateCategory(id: number) {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn &&authStore.role==='admin') {
        try {
          const updateCategoryDTO: CategoryUpdateDTO = {
            Id: id,
            Name: this.currentCategory.Name || '',
            Description: this.currentCategory.Description || '',
            Icon: this.currentCategory.Icon || '',
          };
          await CategoryService.updateCategory(updateCategoryDTO);
          toast.success('Product updated successfully');
          this.resetCurrentCategory();
          this.fetchCategories();
        } catch (error) {
          toast.error('Error updating product');
        }
      }
      else{
        toast.error("You Don't have access")
      }
    },
    handleImageUpload(event: Event) {
      try {
        const files = (event.target as HTMLInputElement).files;
        if (files && files.length != null) {
          const file = files[0];
        const reader = new FileReader();
        reader.onloadend = () => {
            this.currentCategory.Icon = reader.result as string;
        };
        reader.readAsDataURL(file);
      }}
      catch (error) {
        toast.error('Error uploading image');
      }
    },
    resetCurrentCategory(){
        this.currentCategory = {
          Id: null,
          Name: '',
          Description: '',
          Icon: '',
      }

    }
  }
})
export default useCategoryStore;