<script setup>
import { onMounted } from "vue";
import axios from "axios";
import { useBurgerStore } from "@/stores/ProductStore";
import BurgerListing from "./Burger.vue";

const store = useBurgerStore();
defineProps({
  limit: {
    type: Number,
  },
  showButton: {
    type: Boolean,
    default: false,
  },
  showAddProduct: {
    type: Boolean,
    default: true,
  },
});

onMounted(async () => {
  try {
    const response = await axios.get("http://localhost:7168/api/ProductAPI");
    store.burgers = response.data.Result;
    console.log(store.burgers);
  } catch (error) {
    console.error("Error Fetching the Data", error);
  }
});
</script>

<template>
  <section class="bg-blue-50 px-4 py-10">
    <div class="container-xl lg:container">
      <h2 class="text-3xl font-bold text-orange-500 mb-6 text-center">Burgers</h2>
      <div class="grid grid-cols-1 md:grid-cols-3 gap-6">
        <BurgerListing
          v-for="burger in (store.burgers || []).slice(0, limit || store.burgers.length)"
          :key="burger.id"
          :burger="burger"
        />
      </div>
    </div>
  </section>

  <section v-if="showButton" class="m-auto max-w-lg my-10 px-6">
    <RouterLink
      to="/burgers"
      class="block bg-black text-white text-center py-4 px-6 rounded-xl hover:bg-gray-700"
    >
      View All Burgers
    </RouterLink>
  </section>
</template>
