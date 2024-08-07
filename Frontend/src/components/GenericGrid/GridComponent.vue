<!-- GridComponent.vue -->
<script lang="ts" setup>
import { defineProps } from "vue";
import ImageCell from "./ImageCell.vue";
import TextCell from "./TextCell.vue";

// Define an enum for column types
enum ColumnType {
  DEFAULT = "default",
  IMAGE = "image",
}

// Define a type for the columns
interface Column {
  key: string;
  label: string;
  type: ColumnType;
  field?: string;
}

// Define props
const props = defineProps<{
  items: Record<string, any>[];
  columns: Column[];
  limit?: number | null;
  base64Prefix?: string;
}>();

// Define a mapping object using the enum
const componentMapping: Record<ColumnType, any> = {
  [ColumnType.DEFAULT]: TextCell,
  [ColumnType.IMAGE]: ImageCell,
};

// Factory function to get the component based on column type
const getComponent = (column: Column) => {
  return componentMapping[column.type] || componentMapping[ColumnType.DEFAULT];
};
</script>

<template>
  <div class="overflow-x-auto">
    <table class="min-w-full bg-white">
      <thead>
        <tr>
          <th
            v-for="column in props.columns"
            :key="column.key"
            class="py-2 px-4 border-b text-center"
          >
            {{ column.label }}
          </th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="item in props.items.slice(0, props.limit || props.items.length)"
          :key="item.Id"
          class="hover:bg-gray-100"
        >
          <router-link :to="'burgers/' + item.Id" class="contents">
            <td
              v-for="column in props.columns"
              :key="column.key"
              class="py-2 px-4 border-b text-center align-middle"
            >
              <component
                :is="getComponent(column)"
                :item="item"
                :base64Prefix="props.base64Prefix"
                v-bind="column.field ? { field: column.field } : {}"
              />
            </td>
          </router-link>
        </tr>
      </tbody>
    </table>
  </div>
</template>
