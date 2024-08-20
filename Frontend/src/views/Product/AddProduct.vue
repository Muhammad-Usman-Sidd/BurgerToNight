<script setup lang="ts">
import { onMounted } from "vue";
import { useProductStore } from "../../stores/ProductStore";
import { useRouter } from "vue-router";
import { useAuthStore } from "../../stores/AuthStore";
import { useCategoryStore } from "../../stores/CategoryStore";
import UnAuthAdmin from "../../components/Auth/UnAuth(Admin).vue";

const store = useProductStore();
const authStore = useAuthStore();
const categoryStore = useCategoryStore();
const router = useRouter();
store.resetCurrentProduct();

const addProduct = async () => {
  await store.addProduct();
  router.push("/products");
};

onMounted(() => {
  categoryStore.fetchCategories();
});
</script>

<template>
  <UnAuthAdmin />
  <section
    v-if="authStore.isLoggedIn && authStore.role === 'admin'"
    class="bg-orange-50 px-4 py-10 flex justify-center items-center"
  >
    <div class="container-xl lg:container">
      <h2 class="text-3xl font-bold text-orange-500 mb-6 text-center">Add Product</h2>
      <form @submit.prevent="addProduct()" class="bg-white p-6 rounded-lg shadow-md">
        <div class="mb-4">
          <label class="block text-orange-700">Name</label>
          <input
            v-model="store.currentProduct.Name"
            type="text"
            class="w-full p-2 border rounded"
          />
        </div>
        <div class="mb-4">
          <label class="block text-orange-700">Description</label>
          <textarea
            v-model="store.currentProduct.Description"
            class="w-full p-2 border rounded"
          ></textarea>
        </div>
        <div class="mb-4">
          <label class="block text-orange-700">Price</label>
          <input
            v-model="store.currentProduct.Price"
            type="number"
            class="w-full p-2 border rounded"
          />
        </div>
        <div class="mb-4">
          <label class="block text-orange-700">Category</label>
          <select
            v-model="store.currentProduct.CategoryId"
            class="w-full p-2 border rounded"
          >
            <option value="" disabled>Select Category</option>
            <option
              v-for="category in categoryStore.categories"
              :key="category.Id"
              :value="category.Id"
            >
              {{ category.Name }}
            </option>
          </select>
        </div>
        <div class="mb-4">
          <label class="block text-orange-700">Preparing Time</label>
          <input
            v-model="store.currentProduct.PreparingTime"
            type="text"
            class="w-full p-2 border rounded"
          />
        </div>
        <div class="mb-4">
          <label class="block text-orange-700">Image</label>
          <input
            type="file"
            @change="store.handleImageUpload"
            class="w-full p-2 border rounded"
          />
        </div>
        <button type="submit" class="bg-green-500 text-white py-2 px-4 rounded">
          Add Product
        </button>
      </form>
    </div>
  </section>
</template>
