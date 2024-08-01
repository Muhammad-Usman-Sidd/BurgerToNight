<script setup>
import Cards from "../components/Cards.vue";
</script>
<template>
  <section class="py-4">
    <div class="container-xl lg:container m-auto">
      <div class="grid grid-cols-1 md:grid-cols-2 gap-4 p-4 rounded-lg">
        <Cards>
          <h2 class="text-2xl font-bold">Categories</h2>
          <p class="mt-2 mb-4">Explore our Burger Categories</p>
          <RouterLink
            to="/Categories"
            class="inline-block bg-black text-white rounded-lg px-4 py-2 hover:bg-gray-700"
          >
            Categories
          </RouterLink>
        </Cards>
        <Cards bg="bg-orange-100">
          <h2 class="text-2xl font-bold">Burgers</h2>
          <p class="mt-2 mb-4">
            Delicious Burgers waiting for You Check out our latest ones
          </p>
          <RouterLink
            to="/Burgers"
            class="inline-block bg-orange-500 text-white rounded-lg px-4 py-2 hover:bg-orange-600"
          >
            Burgers
          </RouterLink>
        </Cards>
      </div>
    </div>
  </section>
</template>
