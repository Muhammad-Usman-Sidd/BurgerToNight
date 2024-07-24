<script setup>
import { onMounted, computed } from "vue";
import { useBurgerStore } from "@/stores/ProductStore";
import BurgerListing from "./Burger.vue";

const store = useBurgerStore();
defineProps({
  limit: {
    type: Number,
  },
  showButton: {
    type: Boolean,
    default: false,
  },
  showAddProduct: {
    type: Boolean,
    default: true,
  },
});
const totalPages = computed(() => {
  return Math.ceil(store.totalItems / store.pageSize);
});

onMounted(async () => {
  await store.fetchBurgers(store.pageIndex);
});

const nextPage = async () => {
  if (store.pageIndex < totalPages.value) {
    store.pageIndex += 1;
    await store.fetchBurgers(store.pageIndex);
  }
};

const prevPage = async () => {
  if (store.pageIndex > 1) {
    store.pageIndex -= 1;
    await store.fetchBurgers(store.pageIndex);
  }
};
</script>

<template>
  <section class="bg-blue-50 px-4 py-10">
    <div class="container mx-auto">
      <h2 class="text-3xl font-bold text-orange-500 mb-6 text-center">Burgers</h2>
      <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        <BurgerListing
          v-for="burger in (store.burgers || []).slice(0, limit || store.burgers.length)"
          :key="burger.Id"
          :burger="burger"
        />
      </div>
      <section v-if="showButton" class="flex justify-center my-10 px-6">
        <RouterLink
          to="/burgers"
          class="block bg-black text-white text-center py-4 px-6 rounded-xl hover:bg-gray-700"
        >
          View All Burgers
        </RouterLink>
      </section>
      <div v-if="!showButton" class="flex justify-center mt-6 space-x-4">
        <button
          @click="prevPage"
          :disabled="store.pageIndex <= 1"
          class="px-4 py-2 bg-gray-300 text-gray-700 rounded disabled:opacity-50"
        >
          Previous
        </button>
        <span class="flex items-center"
          >Page {{ store.pageIndex }} of {{ totalPages }}</span
        >
        <button
          @click="nextPage"
          :disabled="store.pageIndex >= totalPages"
          class="px-4 py-2 bg-gray-300 text-gray-700 rounded disabled:opacity-50"
        >
          Next
        </button>
      </div>
    </div>
  </section>
</template>

<style scoped>
.container {
  max-width: 1200px;
}
</style>
