<script setup>
import Navbar from './components/Navbar.vue'
import CartIcon from './components/CartIcon.vue';
import SideBar from './components/SideBar.vue';
</script>

<template>
  <CartIcon/>
  <Navbar />
  <SideBar/>
  <RouterView/>
</template>

<style scoped></style>
