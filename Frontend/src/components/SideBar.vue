<script setup lang="ts">
import { computed } from "vue";
import { useBurgerStore } from "../stores/ProductStore";
import { TrashIcon, XMarkIcon } from "@heroicons/vue/24/solid";
import { ProductGetDTO } from "../models/ProductDtos";
const store = useBurgerStore();

// Remove item from cart
const removeFromCart = (burger: ProductGetDTO) => {
  store.removeItem(burger);
};

// Checkout action
const checkout = () => {
  store.checkout();
};

// Toggle sidebar visibility
const toggleSidebar = () => {
  store.toggleSidebar();
};

// Calculate total price of items in the cart
const totalPrice = computed((): string => {
  return Object.values(store.cart)
    .reduce((total: number, item: any) => {
      return total + item.burger.Price * item.quantity;
    }, 0)
    .toFixed(2); // Format to 2 decimal places
});
</script>

<template>
  <div
    v-if="store.showSidebar"
    class="fixed top-0 right-0 w-96 h-full bg-white shadow-lg p-4 z-50 overflow-y-auto"
  >
    <div class="flex justify-between items-center mb-4">
      <h2 class="text-xl font-bold">Cart</h2>
      <button @click="toggleSidebar" class="text-gray-500 hover:text-gray-700">
        <XMarkIcon class="h-6 w-6" />
      </button>
    </div>

    <table class="w-full border-collapse">
      <thead>
        <tr class="border-b">
          <th class="text-left py-2 px-2">Product</th>
          <th class="text-left py-2 px-2">Price</th>
          <th class="text-left py-2 px-2">Quantity</th>
          <th class="text-left py-2 px-2">Total</th>
          <th class="text-left py-2 px-2">Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in store.cart" :key="index" class="border-b">
          <td class="py-2 px-2">{{ item.burger.Name }}</td>
          <td class="py-2 px-2">${{ item.burger.Price.toFixed(2) }}</td>
          <td class="py-2 px-2">{{ item.quantity }}</td>
          <td class="py-2 px-2">${{ (item.burger.Price * item.quantity).toFixed(2) }}</td>
          <td class="py-2 px-2">
            <button @click="removeFromCart(item.burger)" class="text-red-500">
              <TrashIcon class="h-5 w-5" />
            </button>
          </td>
        </tr>
      </tbody>
    </table>

    <div class="flex justify-between items-center mt-4 border-t pt-2">
      <span class="font-semibold">Total:</span>
      <span class="text-orange-600">${{ totalPrice }}</span>
    </div>

    <button @click="checkout" class="w-full mt-4 bg-green-500 text-white py-2 rounded">
      Checkout
    </button>
  </div>
</template>

<style scoped>
/* Add styles for table if needed */
table {
  border-collapse: collapse;
}
th,
td {
  border: 1px solid #ddd;
}
th {
  background-color: #f4f4f4;
}
</style>
