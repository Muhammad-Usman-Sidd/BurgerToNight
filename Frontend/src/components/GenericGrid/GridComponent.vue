<!-- GridComponent.vue -->
<script lang="ts" setup>
import { defineProps } from "vue";
import ImageCell from "./ImageCell.vue";
import TextCell from "./TextCell.vue";

enum ColumnType {
  DEFAULT = "default",
  IMAGE = "image",
}

interface Column {
  key: string;
  label: string;
  type: ColumnType;
  field?: string;
}

const props = defineProps<{
  items: Record<string, any>[];
  columns: Column[];
  limit?: number | null;
  base64Prefix?: string;
}>();

const componentMapping: Record<ColumnType, any> = {
  [ColumnType.DEFAULT]: TextCell,
  [ColumnType.IMAGE]: ImageCell,
};

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
