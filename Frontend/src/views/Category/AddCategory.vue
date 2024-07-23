<script setup>
import { ref } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";

const Category = ref({
  title: "",
  description: "",
});

const router = useRouter();

const addCategory = async () => {
  try {
    await axios.post("http://192.168.15.26:7145/api/CategoryAPI", Category.value);
    router.push("/");
  } catch (error) {
    console.error("Error Adding the Category", error);
  }
};
</script>
<template>
  <section class="bg-blue-50 px-4 py-10">
    <div class="container-xl lg:container">
      <h2 class="text-3xl font-bold text-orange-500 mb-6 text-center">Add Category</h2>
      <form @submit.prevent="addCategory" class="bg-white p-6 rounded-lg shadow-md">
        <div class="mb-4">
          <label class="block text-gray-700">Name</label>
          <input v-model="Category.title" type="text" class="w-full p-2 border rounded" />
        </div>
        <div class="mb-4">
          <label class="block text-gray-700">Description</label>
          <textarea
            v-model="Category.description"
            class="w-full p-2 border rounded"
          ></textarea>
        </div>
        <!-- <div class="mb-4">
            <label class="block text-gray-700">icon (Base64)</label>
            <input v-model="burger.icon" type="text" class="w-full p-2 border rounded" />
          </div> -->
        <button type="submit" class="bg-green-500 text-white py-2 px-4 rounded">
          Add Category
        </button>
      </form>
    </div>
  </section>
</template>
