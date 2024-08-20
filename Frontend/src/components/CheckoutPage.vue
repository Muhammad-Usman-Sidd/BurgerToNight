<template>
  <div class="min-h-screen bg-gray-100 flex flex-col items-center p-4">
    <div class="w-full max-w-lg bg-white rounded-lg shadow-lg p-6">
      <h1 class="text-3xl font-bold text-center mb-4">Order Confirmation</h1>

      <div v-if="orderDto" class="mb-6">
        <div class="text-lg font-semibold">Order Details</div>
        <div class="mt-2">
          <p><span class="font-medium">Name:</span> {{ orderDto.Name }}</p>
          <p><span class="font-medium">Phone Number:</span> {{ orderDto.PhoneNumber }}</p>
          <p><span class="font-medium">Address:</span> {{ orderDto.Address }}</p>
          <p><span class="font-medium">Total Amount:</span> ${{ orderDto.OrderTotal.toFixed(2) }}</p>
        </div>
      </div>

      <div v-if="orderDto.Items.length" class="mb-6">
        <div class="text-lg font-semibold">Order Items</div>
        <ul class="mt-2 list-disc list-inside">
          <li v-for="item in orderDto.Items" :key="item.ProductId" class="flex justify-between">
            <span>{{ item.ProductId }} - Quantity: {{ item.Quantity }}</span>
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
    </div>
  </div>
</template>

<script setup lang="ts">
import { OrderGetDTO } from "../models/OrderDtos";
import { ref, onMounted, computed } from "vue";
import { useOrderStore } from "../stores/OrderStore";
import { useRouter } from "vue-router";
import { useAuthStore } from "../stores/AuthStore";
import { OrderDetailCreateDTO } from "../models/OrderDetailDtos";
import { useToast } from "vue-toastification";

const authStore = useAuthStore();
const orderStore = useOrderStore();
const router = useRouter();
const toast = useToast()

const order = {} as OrderGetDTO;
const orderDto = ref({
  UserId: authStore.user.Id,
  OrderTotal: orderStore.cart.reduce((total, item) => total + item.product.Price * item.quantity, 0),
  Name: authStore.user.Name,
  PhoneNumber: authStore.user.PhoneNumber,
  Address: authStore.user.Address,
  Items: orderStore.cart.map((item) => ({
    ProductId: item.product.Id,
    Quantity: item.quantity,
    Price: item.product.Price,
  })) as OrderDetailCreateDTO[],
});

onMounted(async () => {
  await authStore.getUserById();  
  
});

const confirmOrder = async () => {
  try {
    await orderStore.checkout(orderDto.value);
    router.push(`/orders/${authStore.user.Id}`);
    toast.success("Order placed successfully!");
  } catch (error) {
    console.error("Order placement failed:", error);
    toast.error("Order placement failed. Please try again.");
  }
};
</script>
