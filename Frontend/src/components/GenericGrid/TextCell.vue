<script lang="ts" setup>
import { defineProps } from "vue";

defineProps<{
  item: { product: object };
  field: string;
}>();
</script>

<template>
  <span>{{ item[field] }}</span>
</template>
