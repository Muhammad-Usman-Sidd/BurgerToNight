<script setup>
import { ref, computed } from "vue";

// Define props
const props = defineProps({
  category: Object,
});
const showFullDescription = ref(false);

const toggleFullDescription = () => {
  showFullDescription.value = !showFullDescription.value;
};

const halfDescription = computed(() => {
  const description = props.category?.Description ?? "";
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
        <div class="text-gray-600 grid place-items-center my-2"></div>
        <h3 class="text-xl font-bold">{{ category.Title }}</h3>
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
      <RouterLink
        :to="'categories/' + category.Id"
        class="h-[36px] bg-orange-500 hover:bg-orange-600 text-white px-4 py-2 rounded-lg text-center text-sm"
      >
        Read More
      </RouterLink>
    </div>
  </div>
</template>
