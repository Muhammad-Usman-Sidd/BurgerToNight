<script lang="ts" setup>
import { defineProps, defineEmits } from "vue";
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
}>();

const emits = defineEmits<{
  "row-click": (item: Record<string, any>) => void;
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
          v-for="item in props.items.slice(
            0,
            props.limit || props.items.length
          )"
          :key="item.Id"
          class="hover:bg-orange-100 cursor-pointer"
          @click="$emit('row-click', item)"
        >
          <td
            v-for="column in props.columns"
            :key="column.key"
            class="py-2 px-4 border-b text-center align-middle"
          >
            <component
              :is="getComponent(column)"
              :item="item"
              v-bind="column.field ? { field: column.field } : {}"
            />
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>
