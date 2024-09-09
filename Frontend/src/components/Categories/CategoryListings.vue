<script setup lang="ts">
import { onMounted, ref } from "vue";
import { useCategoryStore } from "../../stores/CategoryStore";
import CategoryCard from "./CategoryCard.vue";
import AddCategory from "../../views/Category/AddCategory.vue";
import CategoryGrid from "./CategoryGrid.vue";
import { useAuthStore } from "../../stores/AuthStore";
const categoryStore = useCategoryStore();
const viewMode = ref<"card" | "grid">("card");
const authStore = useAuthStore();
onMounted(async () => {
  try {
    await categoryStore.fetchCategories();
    console.log("Categories fetched:", categoryStore.categories);
  } catch (error) {
    console.error("Error fetching the data", error);
  }
});

const toggleViewMode = (mode: "card" | "grid") => {
  viewMode.value = mode;
};
</script>

<template>
  <section v-if="authStore.isLoggedIn" class="bg-orange-50 px-4 py-10">
    <div class="container mx-auto">
      <h2 class="text-3xl font-bold text-orange-500 mb-6 text-center">
        Categories
      </h2>
      <div class="flex justify-end mb-4">
        <button
          @click="toggleViewMode('card')"
          :class="{ 'bg-orange-300': viewMode === 'card' }"
          class="px-4 py-2 bg-white border rounded mr-2"
        >
          Card View
        </button>
        <button
          @click="toggleViewMode('grid')"
          :class="{ 'bg-orange-300': viewMode === 'grid' }"
          class="px-4 py-2 bg-white border rounded"
        >
          Grid View
        </button>
      </div>
      <div
        v-if="viewMode === 'card'"
        class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-10"
      >
        <CategoryCard
          v-for="category in (categoryStore.categories || []).slice(
            0,
            categoryStore.categories.length
          )"
          :key="category.Id"
          :category="category"
        />
      </div>

      <div v-if="viewMode === 'grid'">
        <CategoryGrid :categories="categoryStore.categories" />
      </div>
    </div>
  </section>
</template>
