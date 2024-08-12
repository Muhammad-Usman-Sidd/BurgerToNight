<script setup lang="ts">
import { onMounted } from "vue";
import { useRoute, useRouter } from "vue-router";
import { useBurgerStore } from "../../stores/ProductStore";
import { useCategoryStore } from "../../stores/CategoryStore";
import { useAuthStore } from "../../stores/AuthStore";
import UnAuthAdmin from "../../components/UnAuth(Admin).vue";

const route = useRoute();
const router = useRouter();
const authStore = useAuthStore();
const categoryStore = useCategoryStore();
const store = useBurgerStore();
const burgerId = route.params.id;

const update = async () => {
  await store.updateBurger(+burgerId);
  router.push("/burgers");
};

onMounted(async () => {
  await categoryStore.fetchCategories();
  await store.fetchBurgerById(+burgerId);
});
</script>

<template>
  <section
  v-if="authStore.isLoggedIn && authStore.role==='admin'"
    class="bg-blue-50 px-4 py-10 flex justify-center items-center"
  >
    <div class="container-xl lg:container">
      <h2 class="text-3xl font-bold text-orange-500 mb-6 text-center">Edit Burger</h2>
      <form @submit.prevent="update" class="bg-white p-6 rounded-lg shadow-md">
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
              v-for="category in categoryStore.categories"
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
          Save
        </button>
      </form>
    </div>
  </section>
<UnAuthAdmin/>
</template>
