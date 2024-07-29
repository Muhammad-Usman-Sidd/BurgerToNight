<script lang="ts" setup>
import { defineProps } from "vue";

const props = defineProps<{
  item: { Image: string };
  base64Prefix: string;
}>();
</script>

<template>
  <img
    :src="
      props.item.Image.startsWith('data:image/')
        ? props.item.Image
        : props.base64Prefix + props.item.Image
    "
    alt="Item Image"
    class="w-20 h-20 object-cover rounded mx-auto"
  />
</template>
