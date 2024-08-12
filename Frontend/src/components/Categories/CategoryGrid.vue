<script lang="ts" setup>
import { defineProps } from "vue";
import GridComponent from "../GenericGrid/GridComponent.vue";

enum ColumnType {
  DEFAULT = "default",
  IMAGE = "image",
}

const props = defineProps<{
  categories: Record<string, any>[];
}>();

const columns = [
  { key: "title", label: "Title", field: "Title", type: ColumnType.DEFAULT },
  {
    key: "description",
    label: "Description",
    field: "Description",
    type: ColumnType.DEFAULT,
  },
];
</script>

<template>
  <GridComponent
    :items="props.categories"
    :columns="columns"
  />
</template>
