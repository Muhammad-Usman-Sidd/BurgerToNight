<script setup lang="ts">
import { onMounted, reactive } from "vue";
import { useOrderStore } from "../../stores/OrderStore";
import { useProductStore } from "../../stores/ProductStore";
import { ProductGetDTO } from "../../models/ProductDtos";
import { OrderUpdateDTO } from "../../models/OrderDtos";
import { useAuthStore } from "../../stores/AuthStore";
import { useRouter } from "vue-router";
import UnAuthAdmin from "../../components/Auth/UnAuth(Admin).vue";

const router = useRouter();
const orderStore = useOrderStore();
const authStore = useAuthStore();

const updateOrder = async () => {
  await orderStore.updateOrder();
};

const deleteOrder = async (id: number) => {
  await orderStore.deleteOrder(id);
};

onMounted(async () => {
  await orderStore.loadOrders();
});
</script>

<template>
  <div
    v-if="authStore.isLoggedIn && authStore.role === 'admin'"
    class="bg-orange-50 px-4 py-10 flex flex-col items-center"
  >
    <h1 class="text-3xl font-bold text-orange-500 mb-6 text-center">
      Manage Orders
    </h1>

    <div
      v-if="!orderStore.pastOrders.length"
      class="block text-orange-700 text-center"
    >
      No orders found.
    </div>

    <ul v-else class="w-full max-w-4xl">
      <li
        v-for="order in orderStore.pastOrders"
        :key="order.Id"
        class="border rounded-lg shadow-md p-4 mb-4 bg-white"
      >
        <div class="flex justify-between items-center mb-4">
          <h2 class="text-xl font-semibold text-orange-700">
            Order #{{ order.Id }}
          </h2>
          <span class="text-orange-500">{{
            new Date(order.OrderDate).toLocaleDateString()
          }}</span>
        </div>

        <ul class="mb-4">
          <li
            v-for="item in order.Items"
            :key="item.product.Id"
            class="flex justify-between items-center mb-2 p-2 border rounded-lg shadow-sm bg-orange-100"
          >
            <span>
              <img
                v-if="item.product?.Image"
                :src="item.product?.Image"
                alt="Product Image"
                class="w-12 h-12 mr-2 object-cover rounded-full"
              />
              {{ item.product?.Name || "Loading..." }}
            </span>
            <span>Quantity: x{{ item.Quantity }}</span>
            <span
              >Price: ${{
                item.product.Price ? item.product.Price.toFixed(2) : "N/A"
              }}</span
            >
            <span
              >Total: ${{
                item.product.Price
                  ? (item.product.Price * item.Quantity).toFixed(2)
                  : "N/A"
              }}</span
            >
          </li>
        </ul>

        <div class="flex flex-col gap-4 mt-4">
          <div class="flex justify-between items-center">
            <label for="status" class="text-orange-700 font-semibold"
              >Order Status:</label
            >
            <select
              id="status"
              v-model="orderStore.updateStatus.OrderStatus"
              class="border border-orange-300 rounded px-3 py-1"
            >
              <option value="Order Accepted">Order Accepted</option>
              <option value="Preparing">Preparing</option>
              <option value="Out For Delivery">Out For Delivery</option>
              <option value="Delivered">Delivered</option>
            </select>
          </div>

          <div class="flex justify-between items-center">
            <label for="payment" class="text-orange-700 font-semibold"
              >Payment Status:</label
            >
            <select
              id="payment"
              v-model="orderStore.updateStatus.PaymentStatus"
              class="border border-orange-300 rounded px-3 py-1"
            >
              <option value="Pending">Pending</option>
              <option value="Verifying Payment">Verifying Payment</option>
              <option value="Paid">Paid</option>
            </select>
          </div>

          <button
            @click="updateOrder()"
            class="bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600 mt-2"
          >
            Save Changes
          </button>
          <button
            @click="deleteOrder(order.Id)"
            class="bg-red-500 text-white px-4 py-2 rounded hover:bg-red-600 mt-2"
          >
            Delete Order
          </button>
        </div>
      </li>
    </ul>
  </div>
  <UnAuthAdmin />
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

img {
  transition: opacity 0.3s ease;
}
</style>
