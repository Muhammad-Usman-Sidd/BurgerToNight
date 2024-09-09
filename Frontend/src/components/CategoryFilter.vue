<script setup lang="ts">
import { ref, onMounted } from "vue";
import useCategoryStore from "../stores/CategoryStore";
import useProductStore from "../stores/ProductStore";

const categoryStore = useCategoryStore();
const productStore = useProductStore();

const fetchCategories = async () => {
  try {
    await categoryStore.fetchCategories();
  } catch (error) {
    console.error("Error fetching categories:", error);
  }
};

const categoryFilter = (name: string) => {
  productStore.searchQuery = name;
};

onMounted(() => {
  fetchCategories();
  productStore.searchQuery = "";
});
</script>
<template>
  <section class="py-8 bg-orange-800">
    <div class="container mx-auto px-4">
      <h2
        class="text-2xl sm:text-3xl md:text-4xl lg:text-5xl text-white font-bold text-center mb-8"
      >
        Explore Menu
      </h2>
      <div class="flex items-center justify-center gap-2 whitespace-nowrap">
        <div
          v-for="category in categoryStore.categories.slice(0, 6)"
          :key="category.Id"
          class="flex flex-col items-center cursor-pointer hover:shadow-lg p-2 rounded-lg bg-white/40 shadow-md transition-transform transform hover:scale-105"
        >
          <RouterLink to="/products" @click="categoryFilter(category.Name)">
            <div class="h-10/12 lg:w-24 md:w-12 sm:w-6">
              <img
                :src="category.Icon"
                :alt="category.Name"
                class="object-contain"
              />
            </div>
            <p class="text-xs font-semibold text-center mt-1">
              {{ category.Name }}
            </p>
          </RouterLink>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped>
.container {
  max-width: 1200px;
}

.flex-wrap {
  flex-wrap: wrap;
}
</style>
