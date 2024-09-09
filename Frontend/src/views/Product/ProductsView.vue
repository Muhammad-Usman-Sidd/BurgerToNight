<script setup lang="ts">
import { useAuthStore } from "../../stores/AuthStore";
import BackButton from "../../components/BackButton.vue";
import ProductListings from "../../components/Products/ProductListings.vue";
const authStore = useAuthStore();
const Heading = "Menu";
</script>

<template>
  <BackButton />
  <ProductListings
    :showButton="false"
    class="justify-between"
    :heading="Heading"
  />
  <section :showButton="false" class="m-auto max-w-lg my-10 px-6">
    <RouterLink
      v-if="authStore.role === 'admin'"
      to="/add-products"
      class="block bg-black text-white text-center py-4 px-6 rounded-xl hover:bg-orange-700"
    >
      Add Product
    </RouterLink>
  </section>
</template>
