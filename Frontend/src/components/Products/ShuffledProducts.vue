<script setup lang="ts">
import { onMounted, ref } from "vue";
import { useProductStore } from "../../stores/ProductStore";
import ProductCard from "./ProductCard.vue";
import { ProductGetDTO } from "../../models/ProductDtos";
import bgImage from "../../assets/img/bg.jpg";

const store = useProductStore();
const shuffledProducts = ref<ProductGetDTO[]>([]);

interface Props {
  limit?: number;
}

const props = defineProps<Props>();

const shuffleProducts = (products: ProductGetDTO[]) => {
  return products
    .map((product) => ({ product, sort: Math.random() }))
    .sort((a, b) => a.sort - b.sort)
    .map(({ product }) => product);
};

const fetchAndShuffleProducts = async () => {
  await store.fetchProducts();
  shuffledProducts.value = shuffleProducts(store.products);
};

onMounted(async () => {
  await fetchAndShuffleProducts();
});
const handleSearchChange = async (event: Event) => {
  store.searchQuery = (event.target as HTMLInputElement).value;
  store.pageIndex = 1;
  store.products = [];
  await store.fetchProducts();
};
</script>
<template>
  <section
    class="px-4 py-10 bg-cover bg-center relative"
    :style="{ backgroundImage: `url(${bgImage})` }"
  >
    <div class="absolute inset-0 bg-black/40 z-0"></div>
    <div class="xl:container mx-auto relative z-10">
      <h2 class="text-3xl font-bold text-white mb-6 text-center">
        Our Best Sellers
      </h2>
      <div class="mb-10 flex justify-center">
        <input
          type="text"
          v-model="store.searchQuery"
          @change="handleSearchChange"
          placeholder="Search ..."
          class="px-4 py-2 border bg-orange-50 rounded-3xl w-full md:w-1/2"
        />
      </div>

      <div
        v-if="store.products.length === 0"
        class="text-2xl text-center text-orange-700 font-semibold"
      >
        No Products Found
      </div>

      <div v-if="store.products.length > 0">
        <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-8">
          <ProductCard
            v-for="product in (shuffledProducts || []).slice(
              0,
              props.limit || store.totalItems
            )"
            :key="product.Id"
            :product="product"
          />
        </div>

        <div class="flex justify-center my-10 px-6">
          <RouterLink
            to="/products"
            class="block bg-black text-white text-center py-4 px-6 rounded-xl hover:bg-orange-700"
          >
            View All Products
          </RouterLink>
        </div>
      </div>
    </div>
  </section>
</template>
