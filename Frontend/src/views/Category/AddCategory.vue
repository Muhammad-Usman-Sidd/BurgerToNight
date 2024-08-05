<script setup lang="ts">
import { ref } from "vue";
import { useCategoryStore } from "../../stores/CategoryStore.ts";
import { CategoryCreateDTO } from "../../models/CategoryDtos.ts";
import { useAuthStore } from "../../stores/AuthStore.ts";
const addCategory = async () => {
  try {
    await categoryStore.addCategory();
    categoryStore.currentCategory = {};
  } catch (error: any) {
    console.log("Error : ", error);
    toast.error("Error Adding Category");
  }
};
const categoryStore = useCategoryStore();
</script>
<template>
  <section
    v-if="authStore.role !== '' && authStore.role === 'admin'"
    class="bg-blue-50 px-4 py-10 flex justify-center items-center"
  >
    <div class="container-xl lg:container">
      <h2 class="text-3xl font-bold text-orange-500 mb-6 text-center">Add Category</h2>
      <form @submit.prevent="addCategory" class="bg-white p-6 rounded-lg shadow-md">
        <div class="mb-4">
          <label class="block text-gray-700">Title</label>
          <input
            v-model="categoryStore.currentCategory.Title"
            type="text"
            class="w-full p-2 border rounded"
          />
        </div>
        <div class="mb-4">
          <label class="block text-gray-700">Description</label>
          <textarea
            v-model="categoryStore.currentCategory.Description"
            class="w-full p-2 border rounded"
          ></textarea>
        </div>
        <button type="submit" class="bg-green-500 text-white py-2 px-4 rounded">
          Add Category
        </button>
      </form>
    </div>
  </section>
</template>
