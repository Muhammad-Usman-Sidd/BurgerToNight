<script setup>
import Hero from '../components/Hero.vue'
import HomeCards from '../components/HomeCards.vue'
import BurgerListing from '../components/Products/BurgerListings.vue'
</script>

<template>
  <main>
    <Hero/>
    <HomeCards/>
    <BurgerListing :limit="3" :showButton='true' :showAddButton='false'/>
  </main>
</template>
