<script setup lang="ts">
import { onMounted } from "vue";
import { useBurgerStore } from "../../stores/ProductStore";
import { useRouter } from "vue-router";

const store = useBurgerStore();
const router = useRouter();
store.resetCurrentBurger();

onMounted(() => {
  store.fetchCategories();
});

const addProduct = async () => {
  await store.addBurger();
  router.push("/burgers");
};
</script>

<template>
  <section class="bg-blue-50 px-4 py-10 flex justify-center items-center">
    <div class="container-xl lg:container">
      <h2 class="text-3xl font-bold text-orange-500 mb-6 text-center">Add Burger</h2>
      <form @submit.prevent="addProduct" class="bg-white p-6 rounded-lg shadow-md">
        <div class="mb-4">
          <label class="block text-gray-700">Name</label>
          <input
            v-model="store.currentBurger.Name"
            type="text"
            class="w-full p-2 border rounded"
          />
        </div>
        <div class="mb-4">
          <label class="block text-gray-700">Description</label>
          <textarea
            v-model="store.currentBurger.Description"
            class="w-full p-2 border rounded"
          ></textarea>
        </div>
        <div class="mb-4">
          <label class="block text-gray-700">Price</label>
          <input
            v-model="store.currentBurger.Price"
            type="number"
            class="w-full p-2 border rounded"
          />
        </div>
        <div class="mb-4">
          <label class="block text-gray-700">Category</label>
          <select
            v-model="store.currentBurger.BCategoryId"
            class="w-full p-2 border rounded"
          >
            <option value="" disabled>Select Category</option>
            <option
              v-for="category in store.categories"
              :key="category.Id"
              :value="category.Id"
            >
              {{ category.Title }}
            </option>
          </select>
        </div>
        <div class="mb-4">
          <label class="block text-gray-700">Preparing Time</label>
          <input
            v-model="store.currentBurger.PreparingTime"
            type="text"
            class="w-full p-2 border rounded"
          />
        </div>
        <div class="mb-4">
          <label class="block text-gray-700">Image</label>
          <input
            type="file"
            @change="store.handleImageUpload"
            class="w-full p-2 border rounded"
          />
        </div>
        <button type="submit" class="bg-green-500 text-white py-2 px-4 rounded">
          Add Burger
        </button>
      </form>
    </div>
  </section>
</template>
