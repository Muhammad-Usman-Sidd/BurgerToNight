<template>
  <div class="bg-white">
    <div class="pt-6">
      <!-- Breadcrumb -->
      <nav aria-label="Breadcrumb">
        <ol
          role="list"
          class="mx-auto flex max-w-2xl items-center space-x-2 px-4 sm:px-6 lg:max-w-7xl lg:px-8"
        >
          <li v-for="breadcrumb in breadcrumbs" :key="breadcrumb.id">
            <div class="flex items-center">
              <a :href="breadcrumb.href" class="mr-2 text-sm font-medium text-gray-900">{{
                breadcrumb.name
              }}</a>
              <svg
                width="16"
                height="20"
                viewBox="0 0 16 20"
                fill="currentColor"
                aria-hidden="true"
                class="h-5 w-4 text-gray-300"
              >
                <path d="M5.697 4.34L8.98 16.532h1.327L7.025 4.341H5.697z" />
              </svg>
            </div>
          </li>
          <li class="text-sm">
            <a
              aria-current="page"
              class="font-medium text-gray-500 hover:text-gray-600"
              >{{ product.name }}</a
            >
          </li>
        </ol>
      </nav>

      <!-- Order Summary -->
      <div
        class="mx-auto max-w-2xl px-4 pt-10 sm:px-6 lg:grid lg:max-w-7xl lg:grid-cols-3 lg:gap-x-8 lg:px-8 lg:pt-16"
      >
        <div class="lg:col-span-2 lg:border-r lg:border-gray-200 lg:pr-8">
          <h1 class="text-2xl font-bold tracking-tight text-gray-900 sm:text-3xl">
            Checkout
          </h1>
        </div>
        <div class="mt-4 lg:mt-0 lg:row-span-3">
          <h2 class="text-lg font-medium text-gray-900">Order Details</h2>
          <ul class="mt-4 space-y-2">
            <li
              v-for="item in order.Items"
              :key="item.ProductId"
              class="text-sm text-gray-600"
            >
              {{ item.Quantity }}x {{ item.ProductName }} - {{ item.Price }} each
            </li>
          </ul>
          <p class="mt-6 text-lg font-medium text-gray-900">
            Total: {{ order.OrderTotal }}
          </p>
        </div>
      </div>

      <!-- User Details -->
      <div class="mx-auto max-w-2xl px-4 pt-10 sm:px-6 lg:max-w-7xl lg:px-8 lg:pt-16">
        <h2 class="text-lg font-medium text-gray-900">User Information</h2>
        <div class="mt-4">
          <p class="text-sm text-gray-600">Name: {{ order.Name }}</p>
          <p class="text-sm text-gray-600">Phone: {{ order.PhoneNumber }}</p>
          <p class="text-sm text-gray-600">Address: {{ order.Address }}</p>
        </div>
      </div>

      <!-- Place Order Button -->
      <div class="mx-auto max-w-2xl px-4 pt-10 sm:px-6 lg:max-w-7xl lg:px-8 lg:pt-16">
        <button
          @click="confirmOrder"
          class="w-full bg-indigo-600 text-white py-3 px-6 rounded-md hover:bg-indigo-700"
        >
          Place Order
        </button>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { OrderGetDTO } from "../models/OrderDtos";
import { ref, onMounted } from "vue";
import { useOrderStore } from "../stores/OrderStore";
import { useRouter } from "vue-router";
import { useAuthStore } from "../stores/AuthStore";

const authStore= useAuthStore();
const orderStore = useOrderStore();
const router = useRouter();

const order = ref<OrderGetDTO | null>(null);
const breadcrumbs = ref([
  { id: 1, name: "Home", href: "/" },
  { id: 2, name: "Checkout", href: "/checkout" },
]);

onMounted(async() => {
 await authStore.getUserById();
});

const confirmOrder = async () => {
  try {
    await orderStore.checkout();
    router.push("/order-confirmation");
  } catch (error) {
    console.error("Order placement failed:", error);
  }
};
</script>
