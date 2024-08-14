<script lang="ts" setup>
import { defineProps } from "vue";

const props = defineProps<{
  item: { Image: string };
}>();
</script>

<template>
  <img
    :src="props.item.Image"
    alt="Item Image"
    class="w-20 h-20 object-cover rounded mx-auto"
  />
</template>
