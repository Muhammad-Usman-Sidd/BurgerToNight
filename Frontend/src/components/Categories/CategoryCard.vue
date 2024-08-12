<script setup lang="ts">
import { ref, computed } from "vue";
import { defineProps } from "vue";
import { RouterLink } from "vue-router";
import { CategoryGetDTO } from "../../models/CategoryDtos";
import { useCategoryStore } from "../../stores/CategoryStore";
const categoryStore = useCategoryStore();
const props = defineProps<{
  category: CategoryGetDTO;
}>();
</script>

<template>
  <div class="bg-white rounded-xl shadow-md relative">
    <div class="p-4">
      <div class="mb-6">
        <h3 class="text-xl font-bold">{{ category.Title }}</h3>
      </div>
      <div class="mb-5">
        <div>{{ category.Description }}</div>
      </div>
      <!-- <RouterLink
        :to="'categories/'"
        class="h-[36px] bg-orange-500 hover:bg-orange-600 text-white px-4 py-2 rounded-lg text-center text-sm"
      >
        Read More
      </RouterLink> -->
    </div>
  </div>
</template>
