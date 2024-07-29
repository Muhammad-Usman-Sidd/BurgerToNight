<script setup lang="ts">
import { ref, computed } from "vue";
import { defineProps } from "vue";
import { RouterLink } from "vue-router";

interface Category {
  Id: number;
  Title: string;
  Description: string;
}

const props = defineProps<{
  category: Category;
}>();

const showFullDescription = ref(false);

const toggleFullDescription = () => {
  showFullDescription.value = !showFullDescription.value;
};

const halfDescription = computed((): string => {
  const description = props.category?.Description ?? "";
  if (!showFullDescription.value && description.length > 90) {
    return description.substring(0, 90) + "...";
  }
  return description;
});
</script>

<template>
  <div class="bg-white rounded-xl shadow-md relative">
    <div class="p-4">
      <div class="mb-6">
        <h3 class="text-xl font-bold">{{ props.category.Title }}</h3>
      </div>

      <div class="mb-5">
        <div>{{ halfDescription }}</div>
        <button
          @click="toggleFullDescription"
          class="text-orange-500 hover:text-orange-600 mb-5"
        >
          {{ showFullDescription ? "Less" : "More" }}
        </button>
      </div>
      <RouterLink
        :to="'categories/' + props.category.Id"
        class="h-[36px] bg-orange-500 hover:bg-orange-600 text-white px-4 py-2 rounded-lg text-center text-sm"
      >
        Read More
      </RouterLink>
    </div>
  </div>
</template>
