<script setup>
import { ref, computed, onMounted } from "vue";
import { useRoute, useRouter } from "vue-router";
import axios from "axios";
import { useBurgerStore } from "@/stores/ProductStore";
import { useToast } from "vue-toastification";

const route = useRoute();
const router = useRouter();
const Toast = useToast();
const store = useBurgerStore();
const BurgerId = route.params.id;
const deleteBurger = async () => {
  try {
    const confirmMessage = window.confirm("Are you sure you want to delete this burger?");
    if (confirmMessage) {
      await axios.delete(`http://localhost:7168/api/ProductAPI/${BurgerId}`);
      Toast.success("Burger Deleted Successfully");
      router.push("/burgers");
      store.resetCurrentBurger();
    }
  } catch (error) {
    console.error("Error deleting burger", error);
    Toast.error("Deleting failed");
  }
};

const image = computed(() => {
  const imageData = store.currentBurger.Image;
  const base64Prefix = "data:image/*;base64,";

  if (imageData && imageData.startsWith("data:image/")) {
    return imageData;
  } else {
    return base64Prefix + imageData;
  }
});

onMounted(async () => {
  await store.fetchBurgerById(BurgerId);
});
</script>

<template>
  <section class="bg-orange-50">
    <div class="container m-auto py-10 px-6">
      <div class="grid grid-cols-1 md:grid-cols-3 w-full gap-6">
        <aside>
          <div class="bg-white p-6 rounded-lg shadow-md">
            <h3 class="text-xl font-bold mb-6">Burger Info</h3>
            <div class="text-gray-600 grid place-items-center my-2">
              <img
                :src="image"
                alt="Burger Image"
                class="w-70 h-64 object-cover rounded mx-0"
              />
            </div>
            <p class="my-2">{{ store.currentBurger.Name }}</p>
            <hr class="my-4" />
            <h3 class="text-xl">Category:</h3>
            <p class="my-2 bg-orange-100 p-2 font-bold">
              {{ store.currentBurger.burgerCategory }}
            </p>
            <h3 class="text-xl">Price:</h3>
            <p class="my-2 bg-orange-100 p-2 font-bold">
              ${{ store.currentBurger.Price }}
            </p>
          </div>
        </aside>
        <main class="md:col-span-2">
          <div class="bg-white p-6 rounded-lg shadow-md text-center md:text-left">
            <h1 class="text-3xl font-bold mb-4">{{ store.currentBurger.Name }}</h1>
            <!-- <div
              class="text-gray-500 mb-4 flex align-middle justify-center md:justify-start"
            >
              <i class="fa-solid fa-location-dot text-lg text-orange-700 mr-2"></i>
              <p class="text-orange-700">{{ store.currentBurger.bCategoryId }}</p>
            </div> -->
          </div>

          <div class="bg-white p-6 rounded-lg shadow-md mt-6">
            <h3 class="text-orange-800 text-lg font-bold mb-6">Burger Description</h3>
            <p class="mb-4">{{ store.currentBurger.Description }}</p>
            <h3 class="text-orange-800 text-lg font-bold mb-2">Preparing Time:</h3>
            <p class="mb-4">{{ store.currentBurger.PreparingTime }} min</p>
          </div>
          <div class="bg-white p-6 rounded-lg shadow-md mt-6">
            <h3 class="text-xl font-bold mb-6">Manage Burger</h3>
            <RouterLink
              :to="`/burgers/edit/${store.currentBurger.Id}`"
              class="bg-orange-500 hover:bg-orange-600 text-white text-center font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline mt-4 block"
            >
              Edit Burger
            </RouterLink>
            <button
              @click="deleteBurger"
              class="bg-red-500 hover:bg-red-600 text-white font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline mt-4 block"
            >
              Delete Burger
            </button>
          </div>
        </main>
      </div>
    </div>
  </section>
</template>
