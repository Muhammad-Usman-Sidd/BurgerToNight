<script setup lang="ts">
import { onMounted, computed, ref } from "vue";
import { useProductStore } from "../../stores/ProductStore";
import ProductCard from "./ProductCard.vue";
import ProductGrid from "./ProductGrid.vue";
import { ProductGetDTO } from "../../models/ProductDtos";
import { useOrderStore } from "../../stores/OrderStore";

const store = useProductStore();
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
  await fetchProducts();
});

const nextPage = async () => {
  if (store.pageIndex < totalPages.value) {
    store.pageIndex += 1;
    await fetchProducts();
  }
};

const prevPage = async () => {
  if (store.pageIndex > 1) {
    store.pageIndex -= 1;
    await fetchProducts();
  }
};

const toggleViewMode = (mode: "card" | "grid") => {
  viewMode.value = mode;
};

const addToCart = (product: ProductGetDTO, quantity: number) => {
  orderStore.addToCart(product, quantity);
};

const fetchProducts = async () => {
  await store.fetchProducts();
};

const handleSearchChange = async (event: Event) => {
  store.searchQuery = (event.target as HTMLInputElement).value;
  store.pageIndex = 1;
  store.products = [];
  await fetchProducts();
};
</script>
<template>
  <section class="bg-blue-50 px-4 py-10">
    <div class="container mx-auto">
      <h2 class="text-3xl font-bold text-orange-500 mb-6 text-center">Menu</h2>
      <div class="mb-4 flex justify-center">
        <input
          type="text"
          v-model="store.searchQuery"
          @input="handleSearchChange"
          placeholder="Search for products..."
          class="px-4 py-2 border rounded w-full md:w-1/2"
        />
      </div>

      <div
        v-if="store.products.length === 0"
        class="text-2xl text-center text-gray-700 font-semibold"
      >
        No Products Found
      </div>

      <div v-if="store.products.length > 0">
        <div class="flex justify-end mb-4">
          <button
            v-if="!props.showButton"
            @click="toggleViewMode(viewMode === 'card' ? 'grid' : 'card')"
            class="px-4 py-2 bg-white border rounded transition-colors"
            :class="{
              'bg-gray-300': viewMode === 'card' || viewMode === 'grid',
              'text-gray-700': viewMode === 'card' || viewMode === 'grid',
              'hover:bg-gray-100': viewMode === 'card' || viewMode === 'grid',
            }"
          >
            {{ viewMode === "card" ? "Switch to Grid View" : "Switch to Card View" }}
          </button>
        </div>

        <div
          v-if="viewMode === 'card'"
          class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6"
        >
          <ProductCard
            v-for="product in (store.products || []).slice(
              0,
              props.limit || store.totalItems
            )"
            :key="product.Id"
            :product="product"
            @add-to-cart="addToCart"
          />
        </div>

        <div v-if="viewMode === 'grid'">
          <ProductGrid :products="store.products" />
        </div>

        <section v-if="props.showButton" class="flex justify-center my-10 px-6">
          <RouterLink
            to="/products"
            class="block bg-black text-white text-center py-4 px-6 rounded-xl hover:bg-gray-700"
          >
            View All Products
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
