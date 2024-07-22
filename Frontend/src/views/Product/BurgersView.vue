<script setup>
import BurgerListings from "../../components/Products/BurgerListings.vue";
import BackButton from "@/components/BackButton.vue";
</script>
<template>
  <BackButton />
  <BurgerListings :showButton="false" />
  <section :showButton="false" class="m-auto max-w-lg my-10 px-6">
    <RouterLink
      to="/add-burgers"
      class="block bg-black text-white text-center py-4 px-6 rounded-xl hover:bg-gray-700"
    >
      Add Burger
    </RouterLink>
  </section>
</template>
