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
  <section class="py-8">
    <div class="container mx-auto">
      <h2 class="text-3xl font-bold text-center mb-8">Explore Menu</h2>
      <div class="flex flex-wrap justify-center gap-4">
        <div
          v-for="category in categoryStore.categories.slice(0, 6)"
          :key="category.Id"
          class="flex flex-col items-center cursor-pointer hover:shadow-lg p-4 rounded-lg bg-white shadow-md transition-transform transform hover:scale-105"
        >
          <RouterLink to="/products" @click="categoryFilter(category.Name)">
            <img
              :src="category.Icon"
              :alt="category.Name"
              class="w-24 h-24 object-contain mb-2"
            />
            <p class="text-lg font-semibold text-center">{{ category.Name }}</p>
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

.bg-white {
  background-color: #fff;
}
</style>
