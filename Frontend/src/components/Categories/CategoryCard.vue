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
  <div
    class="bg-orange-50 rounded-2xl shadow-lg overflow-hidden transform transition-transform hover:scale-105 text-center max-w-xs mx-auto"
  >
    <div class="p-5">
      <RouterLink :to="'categories/edit/' + category.Id" class="block">
        <div class="mb-3">
          <div class="bg-orange-100 rounded-2xl overflow-hidden">
            <img
              :src="props.category.Icon"
              alt="Product Icon"
              class="w-full h-60 object-cover"
            />
          </div>
          <h3 class="mt-4 text-lg font-semibold text-orange-800">{{ category.Name }}</h3>
        </div>

        <div class="mb-5">
          <p class="text-orange-600">{{ category.Description }}</p>
        </div>
      </RouterLink>
    </div>
  </div>
</template>
