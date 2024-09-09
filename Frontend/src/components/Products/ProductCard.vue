<script setup lang="ts">
import { ref, computed } from "vue";
import { ProductGetDTO } from "../../models/ProductDtos";
import { useOrderStore } from "../../stores/OrderStore";
import { useAuthStore } from "../../stores/AuthStore";

const authStore = useAuthStore();
const orderStore = useOrderStore();

const props = defineProps<{
  product: ProductGetDTO;
}>();

const showFullDescription = ref(false);

const halfDescription = computed(() => {
  const description = props.product?.Description ?? "";
  if (!showFullDescription.value) {
    return description.substring(0, 90) + "...";
  }
  return description;
});

const addToCart = () => {
  orderStore.addToCart(props.product, 1);
};
</script>

<template>
  <div
    class="bg-orange-200 rounded-full shadow-lg overflow-hidden transform transition-transform hover:scale-105 text-center max-w-xs mx-auto"
  >
    <div class="p-5">
      <RouterLink :to="'products/' + product.Id" class="block">
        <div class="mb-3">
          <div class="bg-orange-100 rounded-full overflow-hidden">
            <img
              :src="props.product.Image"
              alt="Product Image"
              class="w-full h-60 object-cover"
            />
          </div>
          <h3 class="mt-4 text-lg font-semibold text-orange-800">
            {{ product.Name }}
          </h3>
        </div>

        <div class="mb-5">
          <p class="text-orange-600">{{ halfDescription }}</p>
        </div>
        <h3 class="text-lg font-bold text-orange-600 mb-4">
          Price: ${{ product.Price }}
        </h3>
      </RouterLink>
      <div>
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
