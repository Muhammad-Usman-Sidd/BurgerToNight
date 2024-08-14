<script setup lang="ts">
import { onMounted, computed, ref } from "vue";
import { useBurgerStore } from "../../stores/ProductStore";
import BurgerCard from "./BurgerCard.vue";
import BurgerGrid from "./BurgerGrid.vue";
import { ProductGetDTO } from "../../models/ProductDtos";
import { useOrderStore } from "../../stores/OrderStore";

const store = useBurgerStore();
const orderStore = useOrderStore();
const viewMode = ref<"card" | "grid">("card");

interface Props {
  limit?: number;
  showButton?: boolean;
}

const props = defineProps<Props>();

const totalPages = computed(() => {
  return Math.ceil(store.totalItems / store.pageSize);
});

onMounted(async () => {
  await fetchBurgers();
});

const nextPage = async () => {
  if (store.pageIndex < totalPages.value) {
    store.pageIndex += 1;
    await fetchBurgers();
  }
};

const prevPage = async () => {
  if (store.pageIndex > 1) {
    store.pageIndex -= 1;
    await fetchBurgers();
  }
};

const toggleViewMode = (mode: "card" | "grid") => {
  viewMode.value = mode;
};

const addToCart = (burger: ProductGetDTO, quantity: number) => {
  orderStore.addToCart(burger, quantity);
};

const fetchBurgers = async () => {
  await store.fetchBurgers();
};

const handleSearchChange = async (event: Event) => {
  store.searchQuery = (event.target as HTMLInputElement).value;
  store.pageIndex = 1; 
  await fetchBurgers();
  console.log
};
</script>
<template>
  <section class="bg-blue-50 px-4 py-10">
    <div class="container mx-auto">
      <h2 class="text-3xl font-bold text-orange-500 mb-6 text-center">Burgers</h2>
      <div class="mb-4 flex justify-center">
        <input 
          type="text" 
          v-model="store.searchQuery" 
          @input="handleSearchChange"
          placeholder="Search for burgers..." 
          class="px-4 py-2 border rounded w-full md:w-1/2"
        />
      </div>

      <div v-if="store.burgers.length === 0" class="text-2xl text-center">
        No Burgers Found
      </div>

      <div v-if="store.burgers.length > 0">
        <div class="flex justify-end mb-4">
          <button
            @click="toggleViewMode('card')"
            :class="{ 'bg-gray-300': viewMode === 'card' }"
            class="px-4 py-2 bg-white border rounded mr-2"
          >
            Card View
          </button>
          <button
            @click="toggleViewMode('grid')"
            :class="{ 'bg-gray-300': viewMode === 'grid' }"
            class="px-4 py-2 bg-white border rounded"
          >
            Grid View
          </button>
        </div>

        <div
          v-if="viewMode === 'card'"
          class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6"
        >
          <BurgerCard
            v-for="burger in (store.burgers || []).slice(0, props.limit || store.totalItems)"
            :key="burger.Id"
            :burger="burger"
            @add-to-cart="addToCart"
          />
        </div>

        <div v-if="viewMode === 'grid'">
          <BurgerGrid :burgers="store.burgers" />
        </div>

        <section v-if="props.showButton" class="flex justify-center my-10 px-6">
          <RouterLink
            to="/burgers"
            class="block bg-black text-white text-center py-4 px-6 rounded-xl hover:bg-gray-700"
          >
            View All Burgers
          </RouterLink>
        </section>
        <div v-if="!props.showButton" class="flex justify-center mt-6 space-x-4">
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
    </div>
  </section>
</template>


<style scoped>
.container {
  max-width: 1200px;
}
</style>
