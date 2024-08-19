<script setup lang="ts">
import { useAuthStore } from "../../stores/AuthStore";
import BackButton from "../../components/BackButton.vue";
import BurgerListings from "../../components/Products/BurgerListings.vue";
const authStore = useAuthStore();
</script>

<template>
  <BackButton />
  <BurgerListings :showButton="false" class="justify-between" />
  <section :showButton="false" class="m-auto max-w-lg my-10 px-6">
    <RouterLink
      v-if="authStore.role === 'admin'"
      to="/add-burgers"
      class="block bg-black text-white text-center py-4 px-6 rounded-xl hover:bg-gray-700"
    >
      Add Burger
    </RouterLink>
  </section>
</template>
