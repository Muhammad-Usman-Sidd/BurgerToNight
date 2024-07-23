<script setup>
import CategoryListing from "./Category.vue";
import AddCategory from "../../views/Category/AddCategory.vue";
import { onMounted } from "vue";
import axios from "axios";
import { useBurgerStore } from "@/stores/ProductStore";

const store = useBurgerStore();

defineProps({
  showAddButton: {
    type: Boolean,
    default: true,
  },
});

onMounted(async () => {
  try {
    const CategoryAPI = await axios.get("http://192.168.15.26:7168/api/CategoryAPI");
    store.categories = CategoryAPI.data.Result;
    console.log("testing phase", store.categories);
  } catch (error) {
    console.error("Error Fetching the Data", error);
  }
});
</script>

<template>
  <section class="bg-blue-50 px-4 py-10">
    <div class="container-xl lg:container">
      <h2 class="text-3xl font-bold text-orange-500 mb-6 text-center">Categories</h2>
      <div class="grid grid-cols-1 md: grid-cols-3 gap-6">
        <CategoryListing
          v-for="category in store.categories"
          :key="category.id"
          :category="category"
        />
      </div>
    </div>
  </section>

  <AddCategory v-if="showAddButton" />
</template>
