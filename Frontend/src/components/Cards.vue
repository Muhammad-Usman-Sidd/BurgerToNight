<script setup lang="ts">
import { defineProps } from "vue";
defineProps({
  bg: {
    type: String,
    default: "bg-orange-100",
  },
});
</script>
<template>
  <div :class="`${bg} p-6 rounded-lg shadow-md`">
    <slot></slot>
  </div>
</template>
