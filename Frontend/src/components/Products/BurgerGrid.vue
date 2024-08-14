<script lang="ts" setup>
import { defineProps } from "vue";
import { useRouter } from "vue-router";
import GridComponent from "../GenericGrid/GridComponent.vue";

enum ColumnType {
  DEFAULT = "default",
  IMAGE = "image",
}

const props = defineProps<{
  burgers: Record<string, any>[];
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

const router = useRouter();

const handleRowClick = (burger: Record<string, any>) => {
  router.push({ name: "burger", params: { id: burger.Id } });
};
</script>

<template>
  <GridComponent
    :items="burgers"
    :columns="columns"
    @row-click="handleRowClick"
  />
</template>
