<script setup lang="ts">
import Hero from "../components/Hero.vue";
import HomeCards from "../components/CategoryFilter.vue";
import ShuffledProductListing from "../components/Products/ShuffledProducts.vue";
import Footer from "../components/Footer.vue";
const Title = "Bite Quest";
const SubTitle = "Carving For Fast Food...";
</script>

<template>
  <main>
    <Hero :title="Title" :subtitle="SubTitle" />
    <HomeCards />
    <ShuffledProductListing class="justify-between" :limit="4" />
    <Footer/>
  </main>
</template>
