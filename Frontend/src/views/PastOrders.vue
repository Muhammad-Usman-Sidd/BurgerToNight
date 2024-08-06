<script setup lang="ts">
import { onMounted } from "vue";
import { useCartStore } from "../stores/CartStore";

const cartStore = useCartStore();

onMounted(async () => {
  await cartStore.loadPastOrders();
  console.log(cartStore.pastOrders);
});
</script>

<template>
  <div class="bg-blue-50 px-4 py-10 flex flex-col items-center">
    <h1 class="text-3xl font-bold text-orange-500 mb-6 text-center">Past Orders</h1>

    <div
      v-if="!cartStore.pastOrders || cartStore.pastOrders.length === 0"
      class="block text-gray-700 text-center"
    >
      No past orders found.
    </div>

    <ul v-else class="w-full max-w-4xl">
      <li
        v-for="(order, index) in cartStore.pastOrders.Items"
        :key="order"
        class="border rounded-lg shadow-md p-4 mb-4 bg-white"
      >
        <div class="flex justify-between items-center mb-4">
          <h2 class="text-xl font-semibold text-orange-700">Order #{{ index + 1 }}</h2>
          <span class="text-gray-500">{{ cartStore.pastOrders.Id }}</span>
        </div>

        <ul class="mb-4">
          <li
            class="flex justify-between items-center mb-2 p-2 border rounded-lg shadow-sm bg-orange-100"
          >
            <span>Product ID: {{ order.ProductId }}</span>
            <span>Quantity: x{{ order.Quantity }}</span>
            <span>Price: ${{ order.Price ? order.Price.toFixed(2) : 'N/A' }}</span>
          </li>
        </ul>

        <div class="flex justify-between items-center mt-2">
          <span class="font-semibold text-orange-700">
            Total: ${{ (cartStore.pastOrders.Items || []).reduce((total :number, item :any) => total + (item.Price ? item.Price * item.Quantity : 0), 0).toFixed(2) }}
          </span>
          <button
            @click="cartStore.addToCart(order, 1)"
            class="bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600"
          >
            Add to Cart
          </button>
          <button
            @click="cartStore.checkout"
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
