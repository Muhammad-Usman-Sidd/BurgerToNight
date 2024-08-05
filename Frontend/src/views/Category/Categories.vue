<script setup lang="ts">
import CategoryListings from "../../components/Categories/CategoryListings.vue";
import AddCategory from "./AddCategory.vue";
</script>
<template>
  <CategoryListings :showButton="false" />
  <AddCategory />
</template>
