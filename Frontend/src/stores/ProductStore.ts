import { defineStore } from 'pinia';
import { useToast } from 'vue-toastification';
import ProductService from '../services/ProductService';
import { ProductGetDTO, ProductUpdateDTO } from '../models/ProductDtos';
import { APIResponse } from '../models/APIResult';
import { useAuthStore } from './AuthStore';
import Swal from 'sweetalert2';

const toast = useToast();
export const useProductStore = defineStore('product', {
  state: () => ({
    products: [] as ProductGetDTO[],
    currentProduct: {} as any,
    totalItems: 0,
    pageIndex: 1,
    pageSize: 8,
    searchQuery: '',
  }),
  actions: {
    async fetchProducts() {
      try {
        const response: APIResponse<any> = await ProductService.getAllProducts(this.pageIndex, this.pageSize, this.searchQuery);
        this.products = response.Result.Products || [];
        console.log(this.products)
        this.totalItems = response.Result.TotalCount;
      } catch (error) {
        console.log(`Error fetching products: ${error}`);
        this.products = []; 
      }
    },
    async fetchProductById(id: number) :Promise<ProductGetDTO> {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn) {
        try {
          const response: APIResponse<ProductGetDTO> = await ProductService.getProduct(id);
          this.currentProduct = response.Result;
          return response.Result
        } catch (error) {
          toast.error('Error fetching product by ID');
          return this.currentProduct
        }
      }
      else{
        toast.error('Please login to access this feature');
        return this.currentProduct
      }
    },
    async addProduct() {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn && authStore.role==='admin') {
        try {
          console.log(this.currentProduct)
          await ProductService.createProduct(this.currentProduct);
          this.resetCurrentProduct();
          toast.success('Product added successfully');
          this.fetchProducts();
        } catch (error) {
          toast.error('Error adding product');
        }
      }
      else{
        toast.error('Please login to access this feature');
      }
    },
    async updateProduct(id: number) {
      const authStore = useAuthStore();
      if (authStore.isLoggedIn &&authStore.role==='admin') {
        try {
          const updateProductDTO: ProductUpdateDTO = {
            Id: id,
            Name: this.currentProduct.Name || '',
            Description: this.currentProduct.Description || '',
            Price: this.currentProduct.Price || 0,
            PreparingTime: this.currentProduct.PreparingTime || '',
            CategoryId: this.currentProduct.CategoryId || null,
            Image: this.currentProduct.Image || '',
          };
          await ProductService.updateProduct(updateProductDTO);
          toast.success('Product updated successfully');
          this.resetCurrentProduct();
          this.fetchProducts();
        } catch (error) {
          toast.error('Error updating product');
        }
      }
      else{
        toast.error("You Don't have access")
      }
    },
    
    async deleteProduct(id: number) {
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
            this.products = this.products.filter(product => product.Id !== id);
            toast.success('Product deleted successfully');
          } catch (error) {
            toast.error('Error deleting product');
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
            this.currentProduct.Image = reader.result as string;
        };
        reader.readAsDataURL(file);
      }}
      catch (error) {
        toast.error('Error uploading image');
      }
    },    
    resetCurrentProduct() {
      this.currentProduct = {
        Name: '',
        Description: '',
        Price: 0,
        PreparingTime: '',
        CategoryId: null,
        Image: '',
        Id: null,
      };
    }
  },
});

export default useProductStore;
