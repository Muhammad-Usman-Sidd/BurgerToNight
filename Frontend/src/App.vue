<script setup>
import { useAuthStore } from "./stores/AuthStore";
import Navbar from "./components/Navbar.vue";
import CartIcon from "./components/CartIcon.vue";
import SideBar from "./components/SideBar.vue";
import Footer from "./components/Footer.vue";
const authStore = useAuthStore();
authStore.initializeStore();
</script>

<template>
  <CartIcon />
  <Navbar />
  <SideBar />
  <RouterView />
  <Footer />
</template>
