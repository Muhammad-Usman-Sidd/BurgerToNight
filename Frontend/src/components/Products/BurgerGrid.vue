<!-- BurgerList.vue -->
<script lang="ts" setup>
import GridComponent from "../GenericGrid/GridComponent.vue";

// Define an enum for column types
enum ColumnType {
  DEFAULT = "default",
  IMAGE = "image",
}

// Define props
const props = defineProps<{
  burgers: Record<string, any>[];
  limit?: number;
}>();

const columns = [
  { key: "image", label: "Image", type: ColumnType.IMAGE },
  { key: "name", label: "Name", field: "Name", type: ColumnType.DEFAULT },
  {
    key: "category",
    label: "Category",
    field: "burgerCategory",
    type: ColumnType.DEFAULT,
  },
  {
    key: "description",
    label: "Description",
    field: "Description",
    type: ColumnType.DEFAULT,
  },
  { key: "price", label: "Price", field: "Price", type: ColumnType.DEFAULT },
  {
    key: "preparingTime",
    label: "Preparing Time",
    field: "PreparingTime",
    type: ColumnType.DEFAULT,
  },
];
</script>

<template>
  <GridComponent
    :items="props.burgers"
    :columns="columns"
    :limit="props.limit"
    base64Prefix="data:image/*;base64,"
  />
</template>
