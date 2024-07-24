<script setup>
import { ref, computed } from "vue";

const props = defineProps({
  burger: Object,
});
const showFullDescription = ref(false);

const toggleFullDescription = () => {
  showFullDescription.value = !showFullDescription.value;
};

const image = computed(() => {
  const imageData = props.burger.Image;
  const base64Prefix = "data:image/*;base64,";

  if (imageData && imageData.startsWith("data:image/")) {
    return imageData;
  } else {
    return base64Prefix + imageData;
  }
});

const halfDescription = computed(() => {
  const description = props.burger?.Description ?? "";
  if (!showFullDescription.value) {
    return description.substring(0, 90) + "...";
  }
  return description;
});
</script>

<template>
  <div class="bg-white rounded-xl shadow-md relative">
    <div class="p-4">
      <div class="mb-6">
        <div class="text-gray-600 grid place-items-center my-2">
          <img
            :src="image"
            alt="Burger Image"
            class="w-70 h-64 object-cover rounded mx-0"
          />
        </div>
        <h3 class="text-xl font-bold">{{ burger.Name }}</h3>
        <h4 class="text-gray-500">Category: {{ burger.burgerCategory }}</h4>
      </div>

      <div class="mb-5">
        <div>
          {{ halfDescription }}
        </div>
        <button
          @click="toggleFullDescription"
          class="text-orange-500 hover:text-orange-600 mb-5"
        >
          {{ showFullDescription ? "Less" : "More" }}
        </button>
      </div>

      <h3 class="text-orange-500 mb-2">Price :${{ burger.Price }}</h3>
      <div class="flex flex-col lg:flex-row justify-between mb-4">
        <h3 class="text-orange-700 mb-3">
          Preparing Time {{ burger.PreparingTime }} min
        </h3>
        <RouterLink
          :to="'burgers/' + burger.Id"
          class="h-[36px] bg-orange-500 hover:bg-orange-600 text-white px-4 py-2 rounded-lg text-center text-sm"
        >
          Read More
        </RouterLink>
      </div>
    </div>
  </div>
</template>
