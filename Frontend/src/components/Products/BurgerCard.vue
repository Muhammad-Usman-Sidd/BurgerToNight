<script setup lang="ts">
import { ref, computed } from "vue";
import { ProductGetDTO } from "../../models/ProductDtos";
import { useOrderStore } from "../../stores/OrderStore";
import { useAuthStore } from "../../stores/AuthStore";

const authStore = useAuthStore();
const orderStore = useOrderStore();

const props = defineProps<{
  burger: ProductGetDTO;
}>();

const showFullDescription = ref(false);

const toggleFullDescription = () => {
  showFullDescription.value = !showFullDescription.value;
};

const halfDescription = computed(() => {
  const description = props.burger?.Description ?? "";
  if (!showFullDescription.value) {
    return description.substring(0, 90) + "...";
  }
  return description;
});

const addToCart = () => {
  orderStore.addToCart(props.burger, 1);
};
</script>

<template>
  <div
    class="bg-gray-50 rounded-full shadow-lg overflow-hidden transform transition-transform hover:scale-105 text-center max-w-xs mx-auto"
  >
    <div class="p-5">
      <RouterLink :to="'burgers/' + burger.Id" class="block">
        <div class="mb-3">
          <div class="bg-gray-100 rounded-full overflow-hidden">
            <img
              :src="props.burger.Image"
              alt="Burger Image"
              class="w-full h-60 object-cover"
            />
          </div>
          <h3 class="mt-4 text-lg font-semibold text-gray-800">{{ burger.Name }}</h3>
        </div>

        <div class="mb-5">
          <p class="text-gray-600">{{ halfDescription }}</p>
        </div>
        <h3 class="text-lg font-bold text-orange-600 mb-4">Price: ${{ burger.Price }}</h3>
      </RouterLink>
      <div v-if="authStore.isLoggedIn && authStore.role === 'customer'">
        <button
          @click="addToCart"
          class="bg-green-600 hover:bg-green-700 text-white px-6 py-3 mb-3 rounded-full text-sm font-medium"
        >
          Add to Cart
        </button>
      </div>
    </div>
  </div>
</template>
