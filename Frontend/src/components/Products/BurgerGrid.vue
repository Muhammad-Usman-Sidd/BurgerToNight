<script setup>
const props = defineProps({
  burgers: {
    type: Array,
    required: true,
  },
  limit: {
    type: Number,
    default: null,
  },
});
const base64Prefix = "data:image/*;base64,";
</script>

<template>
  <div class="overflow-x-auto">
    <table class="min-w-full bg-white">
      <thead>
        <tr>
          <th class="py-2 px-4 border-b text-center">Image</th>
          <th class="py-2 px-4 border-b text-center">Name</th>
          <th class="py-2 px-4 border-b text-center">Category</th>
          <th class="py-2 px-4 border-b text-center">Description</th>
          <th class="py-2 px-4 border-b text-center">Price</th>
          <th class="py-2 px-4 border-b text-center">Preparing Time</th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="burger in burgers.slice(0, limit || burgers.length)"
          :key="burger.Id"
          class="hover:bg-gray-100"
        >
          <RouterLink :to="'burgers/' + burger.Id" class="contents">
            <td class="py-2 px-4 border-b text-center">
              <img
                :src="
                  burger.Image.startsWith('data:image/')
                    ? burger.Image
                    : base64Prefix + burger.Image
                "
                alt="Burger Image"
                class="w-20 h-20 object-cover rounded mx-auto"
              />
            </td>
            <td class="py-2 px-4 border-b text-center align-middle">{{ burger.Name }}</td>
            <td class="py-2 px-4 border-b text-center align-middle">
              {{ burger.burgerCategory }}
            </td>
            <td class="py-2 px-4 border-b text-center align-middle">
              {{ burger.Description }}
            </td>
            <td class="py-2 px-4 border-b text-center align-middle">
              ${{ burger.Price }}
            </td>
            <td class="py-2 px-4 border-b text-center align-middle">
              {{ burger.PreparingTime }} min
            </td>
          </RouterLink>
        </tr>
      </tbody>
    </table>
  </div>
</template>
