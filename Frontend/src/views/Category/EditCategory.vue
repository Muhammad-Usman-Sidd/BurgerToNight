<script setup lang="ts">
import { onMounted } from "vue";
import { useRoute, useRouter } from "vue-router";
import { useCategoryStore } from "../../stores/CategoryStore";
import { useAuthStore } from "../../stores/AuthStore";
import UnAuthAdmin from "../../components/Auth/UnAuth(Admin).vue";

const route = useRoute();
const router = useRouter();
const authStore = useAuthStore();
const categoryStore = useCategoryStore();
const categoryId = route.params.id;

const update = async () => {
  await categoryStore.updateCategory(+categoryId);
  router.push("/categories");
};
const deleteCategory = async () =>{
    await categoryStore.deleteCategory(+categoryId);
}

onMounted(async () => {
  await categoryStore.fetchCategoryById(+categoryId);
});
</script>

<template>
  <section
  v-if="authStore.isLoggedIn && authStore.role==='admin'"
    class="bg-orange-50 px-4 py-10 flex justify-center items-center"
  >
    <div class="container-xl lg:container">
      <h2 class="text-3xl font-bold text-orange-500 mb-6 text-center">Edit Product</h2>
      <form @submit.prevent="update" class="bg-white p-6 rounded-lg shadow-md">
        <div class="mb-4">
          <label class="block text-orange-700">Name</label>
          <input
            v-model="categoryStore.currentCategory.Name"
            type="text"
            class="w-full p-2 border rounded"
          />
        </div>
        <div class="mb-4">
          <label class="block text-orange-700">Description</label>
          <textarea
            v-model="categoryStore.currentCategory.Description"
            class="w-full p-2 border rounded"
          ></textarea>
        </div>
        <div class="mb-4">
          <label class="block text-orange-700">Icon</label>
          <input
            type="file"
            @change="categoryStore.handleImageUpload"
            class="w-full p-2 border rounded"
          />
        </div>
        <button type="submit" class="bg-green-500 hover:bg-green-600 text-white font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline mt-4 block">
          Save
        </button>
        <button
        @click="deleteCategory"
            class="bg-red-500 hover:bg-red-600 text-white font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline mt-4 block"
            >
            Delete Product
        </button>
      </form>
    </div>
  </section>
<UnAuthAdmin/>
</template>
