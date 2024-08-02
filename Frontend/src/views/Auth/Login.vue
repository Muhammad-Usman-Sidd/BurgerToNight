<script setup lang="ts">
import { ref } from "vue";
import AuthService from "../../services/AuthService";
import { APIResponse } from "../../models/APIResult.ts";
import { useAuthStore } from "../../stores/AuthStore.ts";
const authStore = useAuthStore();
const loginRequest = ref({
  userName: "",
  password: "",
});

const errorMessage = ref("");

const authService = new AuthService(import.meta.env.VITE_API_URL);

const login = async () => {
  try {
    const response: APIResponse<any[]> = await authService.login(loginRequest.value);
    if (response.IsSuccess) {
      // Handle success, for example, store the token and redirect
      console.log("Login successful:", response.Result.Token);

      // Store the token
      authStore.token = response.Result.Token;
      authStore.isLoggedIn = true;
      loginRequest.value = {
        userName: "",
        password: "",
      };

      // Redirect to the dashboard or another page
    } else {
      errorMessage.value = response.ErrorMessages.join(", ");
    }
  } catch (error) {
    errorMessage.value = "Failed to login. Please try again.";
  }
};
</script>
<template>
  <div class="flex justify-center items-center min-h-screen bg-gray-100">
    <div class="bg-white p-8 rounded-lg shadow-md w-full max-w-md">
      <h2 class="text-2xl font-semibold mb-6">Login</h2>
      <form @submit.prevent="login">
        <div class="mb-4">
          <label for="userName" class="block text-gray-700">Username:</label>
          <input
            type="text"
            id="userName"
            v-model="loginRequest.userName"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <div class="mb-4">
          <label for="password" class="block text-gray-700">Password:</label>
          <input
            type="password"
            id="password"
            v-model="loginRequest.password"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <button type="submit" class="bg-blue-500 text-white py-2 px-4 rounded-lg w-full">
          Login
        </button>
      </form>
      <div v-if="errorMessage" class="text-red-500 mt-4">{{ errorMessage }}</div>
    </div>
  </div>
</template>
