<script setup lang="ts">
import { ref } from "vue";
import { useAuthStore } from "../../stores/AuthStore";
import { useToast } from "vue-toastification";
import { LoginDTO } from "../../models/AuthDtos";
import { useRouter } from "vue-router";
const router = useRouter();

const toast = useToast();
const authStore = useAuthStore();
const errorMessage = ref<string | null>(null);
const loginUser = (): LoginDTO => ({
  UserName: "",
  Password: "",
});
const user = ref<LoginDTO>(loginUser());

const login = async () => {
  try {
    await authStore.login(user.value);
    toast.success(`Hello ${user.value.UserName}`);
    user.value = loginUser();
    router.push("/products");
  } catch (error: any) {
    errorMessage.value = error.message || "Failed to login. Please try again.";
  }
};
</script>

<template>
  <div
    v-if="!authStore.isLoggedIn"
    class="flex justify-center items-center min-h-screen bg-gray-100"
  >
    <div class="bg-white p-8 rounded-lg shadow-md w-full max-w-md">
      <h2 class="text-2xl font-semibold mb-6">Sign In</h2>
      <form @submit.prevent="login">
        <div class="mb-4">
          <label for="userName" class="block text-gray-700">Username:</label>
          <input
            type="text"
            id="userName"
            v-model="user.UserName"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <div class="mb-4">
          <label for="password" class="block text-gray-700">Password:</label>
          <input
            type="password"
            id="password"
            v-model="user.Password"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <button type="submit" class="bg-blue-500 text-white py-2 px-4 rounded-lg w-full">
          Sign In
        </button>
      </form>
      <div v-if="errorMessage" class="text-red-500 mt-4">{{ errorMessage }}</div>
    </div>
  </div>
</template>
