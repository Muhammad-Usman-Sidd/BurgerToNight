<script setup lang="ts">
import { ShoppingCartIcon } from "@heroicons/vue/24/solid";
import { useOrderStore } from "../stores/OrderStore";

const orderStore = useOrderStore();
</script>

<template>
  <button
    @click="orderStore.toggleSidebar"
    class="fixed bottom-5 right-5 p-3 bg-orange-600 text-white rounded-full shadow-lg hover:bg-orange-700 focus:outline-none focus:ring-2 focus:ring-orange-500 focus:ring-opacity-50 z-50"
  >
    <ShoppingCartIcon class="h-6 w-6" />
  </button>
</template>

