<script setup lang="ts">
import HomeCards from "../components/HomeCards.vue";
import Hero from "../components/Hero.vue";
import BurgerListing from "../components/Products/BurgerListings.vue";
import SideBar from "../components/SideBar.vue";
const Title = "Burger To Night";
const SubTitle = "Carving For Burgers...";
</script>

<template>
  <main>
    <Hero :title="Title" :subtitle="SubTitle" />
    <HomeCards />
    <BurgerListing :limit="3" :showButton="true" :showAddButton="false" />
  </main>
</template>
