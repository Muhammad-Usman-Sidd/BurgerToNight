<script setup lang="ts">
import { ProductGetDTO } from "../models/ProductDtos";
import { useOrderStore } from "../stores/OrderStore";
import { onMounted } from "vue";
const orderStore = useOrderStore();

const addToCart = (order: any) => {
  order.Items.forEach((item: ProductGetDTO, quantity: number) => {
    orderStore.addToCart(item, quantity);
  });
};

const checkout = (order: any) => {
  orderStore.checkout();
};

onMounted(async () => {
  await orderStore.loadPastOrders();
});
</script>
<template>
  <div class="bg-blue-50 px-4 py-10 flex flex-col items-center">
    <h1 class="text-3xl font-bold text-orange-500 mb-6 text-center">Past Orders</h1>

    <div v-if="!orderStore.pastOrders.length" class="block text-gray-700 text-center">
      No past orders found.
    </div>

    <ul v-else class="w-full max-w-4xl">
      <li
        v-for="order in orderStore.pastOrders"
        :key="order.Id"
        class="border rounded-lg shadow-md p-4 mb-4 bg-white"
      >
        <div class="flex justify-between items-center mb-4">
          <h2 class="text-xl font-semibold text-orange-700">Order #{{ order.Id }}</h2>
          <span class="text-gray-500">{{
            new Date(order.OrderDate).toLocaleDateString()
          }}</span>
        </div>

        <ul class="mb-4">
          <li
            v-for="item in order.Items"
            :key="item.ProductId"
            class="flex justify-between items-center mb-2 p-2 border rounded-lg shadow-sm bg-orange-100"
          >
            <span>Product ID: {{ item.ProductId }}</span>
            <span>Quantity: x{{ item.Quantity }}</span>
            <span>Price: ${{ item.Price ? item.Price.toFixed(2) : "N/A" }}</span>
          </li>
        </ul>

        <div class="flex justify-between items-center mt-2">
          <span class="font-semibold text-orange-700">
            Total: ${{
              (order.Items || [])
                .reduce(
                  (total, item) => total + (item.Price ? item.Price * item.Quantity : 0),
                  0
                )
                .toFixed(2)
            }}
          </span>
          <button
            @click="addToCart(order)"
            class="bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600"
          >
            Add to Cart
          </button>
          <button
            @click="checkout(order)"
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
