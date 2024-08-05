<script setup lang="ts">
import { computed, onMounted } from "vue";
import { useBurgerStore } from "../stores/ProductStore";

const store = useBurgerStore();

// Fetch past orders on component mount
onMounted(async () => {
  await store.fetchPastOrders();
});

// Compute past orders from the store
const pastOrders = store.pastOrders;
console.log(pastOrders);
</script>

<template>
  <div class="bg-blue-50 px-4 py-10 flex flex-col items-center">
    <h1 class="text-3xl font-bold text-orange-500 mb-6 text-center">Past Orders</h1>

    <div
      v-if="!pastOrders || pastOrders.length === 0"
      class="block text-gray-700 text-center"
    >
      No past orders found.
    </div>

    <ul v-else class="w-full max-w-4xl">
      <li
        v-for="(order, index) in pastOrders"
        :key="index"
        class="border rounded-lg shadow-md p-4 mb-4 bg-white"
      >
        <div class="flex justify-between items-center mb-4">
          <h2 class="text-xl font-semibold text-orange-700">Order #{{ index + 1 }}</h2>
          <span class="text-gray-500">{{ order.Id }}</span>
        </div>

        <ul class="mb-4">
          <li
            v-for="(i, itemIndex) in order"
            :key="itemIndex"
            class="flex justify-between items-center mb-2 p-2 border rounded-lg shadow-sm bg-orange-100"
          >
            <span>{{ order.Image }}</span>
            <span>x{{ order.BurgerCategory }}</span>
          </li>
        </ul>

        <div class="flex justify-between items-center mt-2">
          <span class="font-semibold text-orange-700">
            Total: ${{ order.Price.toFixed(2) }}
          </span>
          <button
            @click="cartStore.addToCart(order, 1)"
            class="bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600"
          >
            Add to Cart
          </button>
          <button
            @click="store.checkout"
            class="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
          >
            Checkout
          </button>
        </div>
      </li>
    </ul>
  </div>
</template>

<style scoped>
/* Styling for the orders list and items */
ul {
  list-style: none;
  padding: 0;
}

li {
  border-bottom: 1px solid #ddd;
}

li:last-child {
  border-bottom: none;
}

button {
  transition: background-color 0.3s ease;
}
</style>
