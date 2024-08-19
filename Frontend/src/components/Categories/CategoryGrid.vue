<script lang="ts" setup>
import { defineProps } from "vue";
import { useRouter } from "vue-router";
import GridComponent from "../GenericGrid/GridComponent.vue";

enum ColumnType {
  DEFAULT = "default",
  IMAGE = "image",
}

const props = defineProps<{
  categories: Record<string, any>[];
}>();

const columns = [
  { key: "name", label: "Name", field: "Name", type: ColumnType.DEFAULT },
  {
    key: "description",
    label: "Description",
    field: "Description",
    type: ColumnType.DEFAULT,
  },
];

const router = useRouter();

const handleRowClick = (category: Record<string, any>) => {
  router.push({ name: "CategoryDetails", params: { id: category.Id } });
};
</script>

<template>
  <GridComponent
    :items="categories"
    :columns="columns"
    @row-click="handleRowClick"
  />
</template>
