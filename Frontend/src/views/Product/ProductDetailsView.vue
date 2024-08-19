<script setup lang="ts">
import { computed, onMounted } from "vue";
import { useRoute, useRouter } from "vue-router";
import { useProductStore } from "../../stores/ProductStore";
import { useAuthStore } from "../../stores/AuthStore";
import { useOrderStore } from "../../stores/OrderStore";
import UnAuthorized from "../../components/Auth/UnAuthorized.vue";

const route = useRoute();
const router = useRouter();
const store = useProductStore();
const orderStore = useOrderStore();
const authStore = useAuthStore();
const ProductId = route.params.id;

const deleteProduct = async () => {
  await store.deleteProduct(+ProductId);
  router.push("/products");
};

onMounted(async () => {
  await store.fetchProductById(+ProductId);
});
</script>

<template>
  <section v-if="authStore.isLoggedIn" class="bg-orange-50">
    <div class="container m-auto py-10 px-6">
      <div class="grid grid-cols-1 md:grid-cols-3 w-full gap-6">
        <aside>
          <div class="bg-white p-6 rounded-lg shadow-md">
            <h3 class="text-xl font-bold mb-6">Product Info</h3>
            <div class="text-gray-600 grid place-items-center my-2">
              <img
                :src="store.currentProduct.Image"
                alt="Product Image"
                class="w-70 h-64 object-cover rounded mx-0"
              />
            </div>
            <hr class="my-4" />
            <h3 class="text-xl">Category:</h3>
            <p class="my-2 bg-orange-100 p-2 font-bold">
              {{ store.currentProduct.Category }}
            </p>
            <h3 class="text-xl">Price:</h3>
            <p class="my-2 bg-orange-100 p-2 font-bold">
              ${{ store.currentProduct.Price }}
            </p>
          </div>
        </aside>
        <main class="md:col-span-2">
          <div class="bg-white p-6 rounded-lg shadow-md text-center md:text-left">
            <h1 class="text-3xl font-bold mb-4">{{ store.currentProduct.Name }}</h1>
          </div>

          <div class="bg-white p-6 rounded-lg shadow-md mt-6">
            <h3 class="text-orange-800 text-lg font-bold mb-6">Product Description</h3>
            <p class="mb-4">{{ store.currentProduct.Description }}</p>
            <h3 class="text-orange-800 text-lg font-bold mb-2">Preparing Time:</h3>
            <p class="mb-4">{{ store.currentProduct.PreparingTime }} min</p>
          </div>
          <div
            v-if="authStore.isLoggedIn && authStore.role === 'admin'"
            class="bg-white p-6 rounded-lg shadow-md mt-6"
          >
            <h3 class="text-xl font-bold mb-6">Manage Product</h3>
            <RouterLink
              :to="`/products/edit/${store.currentProduct.Id}`"
              class="bg-orange-500 hover:bg-orange-600 text-white text-center font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline mt-4 block"
            >
              Edit Product
            </RouterLink>
            <button
              @click="deleteProduct"
              class="bg-red-500 hover:bg-red-600 text-white font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline mt-4 block"
            >
              Delete Product
            </button>
          </div>
          <div
            v-if="authStore.isLoggedIn && authStore.role === 'customer'"
            class="bg-white p-6 rounded-lg shadow-md mt-6"
          >
            <h3 class="text-xl font-bold mb-6">Manage Product</h3>
            <button
              @click="orderStore.addToCart(store.currentProduct, 1)"
              class="bg-green-500 hover:bg-green-600 text-white font-bold py-4 px-4 rounded-full w-full focus:outline-none focus:shadow-outline mt-8 block"
            >
              Add to Cart
            </button>
          </div>
        </main>
      </div>
    </div>
  </section>
  <UnAuthorized />
</template>
