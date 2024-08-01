<script setup lang="ts">
import CategoryListing from "./CategoryCard.vue";
import AddCategory from "../../views/Category/AddCategory.vue";
import { onMounted } from "vue";
import { defineProps } from "vue";
import { useBurgerStore } from "../../stores/ProductStore";

const store = useBurgerStore();

const props = defineProps({
  showAddButton: {
    type: Boolean,
    default: true,
  },
});

onMounted(async () => {
  try {
    await store.fetchCategories();
    console.log("Categories fetched:", store.categories);
  } catch (error) {
    console.error("Error fetching the data", error);
  }
});
</script>

<template>
  <section class="bg-blue-50 px-4 py-10">
    <div class="container mx-auto">
      <h2 class="text-3xl font-bold text-orange-500 mb-6 text-center">Categories</h2>
      <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        <CategoryListing
          v-for="category in store.categories || []"
          :key="category.id"
          :category="category"
        />
      </div>
    </div>
  </section>
  <AddCategory v-if="props.showAddButton" />
</template>
