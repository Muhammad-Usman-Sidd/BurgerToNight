<script setup lang="ts">
import CategoryListings from "../../components/Categories/CategoryListings.vue";
import { useAuthStore } from "../../stores/AuthStore";
const authStore=useAuthStore()
</script>
<template>
  <CategoryListings :showButton="false" />
    <RouterLink
      v-if="authStore.role === 'admin'"
      to="/add-categories"
      class="block bg-black text-white text-center m-auto max-w-lg my-10 px-6 py-4 px-6 rounded-xl hover:bg-gray-700"
    >
      Add Category
    </RouterLink>
</template>
