<script lang="ts" setup>
import { defineProps } from "vue";

const props = defineProps<{
  item: { burger: object };
  field: string;
}>();
</script>

<template>
  <span>{{ item[field] }}</span>
</template>
