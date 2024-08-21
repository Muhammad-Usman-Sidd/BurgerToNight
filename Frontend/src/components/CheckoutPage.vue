<script setup lang="ts">
import { onMounted } from "vue";
import { useOrderStore } from "../stores/OrderStore";
import { useRouter } from "vue-router";
import { useAuthStore } from "../stores/AuthStore";
import { useToast } from "vue-toastification";

const authStore = useAuthStore();
const orderStore = useOrderStore();
const router = useRouter();
const toast = useToast();

onMounted(async () => {
  await orderStore.readCurrentOrder();
  console.log(orderStore.currentOrder);
});

const confirmOrder = async () => {
  try {
    await orderStore.checkout();
    router.push(`/orders/${authStore.user.Id}`);
    toast.success("Order placed successfully!");
  } catch (error) {
    console.error("Order placement failed:", error);
    toast.error("Order placement failed. Please try again.");
  }
};
</script>

<template>
  <div
    v-if="orderStore.cart.length >= 1 && authStore.isLoggedIn && authStore.role === 'customer'"
    class="min-h-screen bg-gray-100 flex flex-col items-center p-4"
  >
    <div class="w-full max-w-3xl bg-white rounded-lg shadow-lg p-6">
      <h1 class="text-3xl font-bold text-center mb-4">Checkout</h1>

      <div v-if="orderStore.currentOrder" class="mb-6">
        <div class="text-lg font-semibold">Personal Details</div>
        <div class="mt-2">
          <label class="block mb-2">
            <span class="font-medium">Name:</span>
            <input v-model="orderStore.currentOrder.Name" type="text" class="block w-full mt-1 p-2 border rounded" />
          </label>
          <label class="block mb-2">
            <span class="font-medium">Phone Number:</span>
            <input v-model="orderStore.currentOrder.PhoneNumber" type="text" class="block w-full mt-1 p-2 border rounded" />
          </label>
          <label class="block mb-2">
            <span class="font-medium">Address:</span>
            <input v-model="orderStore.currentOrder.Address" type="text" class="block w-full mt-1 p-2 border rounded" />
          </label>
          <p><span class="font-medium">Total Amount:</span> ${{ orderStore.currentOrder.OrderTotal }}</p>
        </div>
      </div>

      <!-- Order Items -->
      <div v-if="orderStore.currentOrder.Items.length" class="mb-6">
        <div class="text-lg font-semibold">Order Items</div>
        <ul class="mt-2">
          <li v-for="item in orderStore.currentOrder.Items" :key="item.ProductId" class="flex items-center justify-between mb-4">
            <img :src="item.ProductImage" alt="Product Image" class="w-16 h-16 rounded" />
            <span>{{ item.ProductName }} - Quantity: {{ item.Quantity }}</span>
            <span>${{ (item.Price * item.Quantity).toFixed(2) }}</span>
          </li>
        </ul>
      </div>

      <button
        @click="confirmOrder"
        class="w-full bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-600 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-opacity-50"
      >
        Confirm Order
      </button>
      <RouterLink
        to="/"
        class="w-full bg-red-500 text-white py-2 px-4 rounded hover:bg-red-600 focus:outline-none focus:ring-2 focus:ring-red-500 focus:ring-opacity-50"
      >
        Cancel
      </RouterLink>
    </div>
  </div>
</template>
