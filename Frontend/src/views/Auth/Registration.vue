<script setup lang="ts">
import { ref } from "vue";
import { useAuthStore } from "../../stores/AuthStore";
import { RegistrationRequestDTO } from "../../models/AuthDtos.ts";

const authStore = useAuthStore();
const errorMessage = ref<string | null>(null);
const user = ref<RegistrationRequestDTO>({
  userName: "",
  email: "",
  password: "",
  role: "",
  secretKey: "",
});

const register = async () => {
  try {
    await authStore.register(user.value);
    user.value = {};
  } catch (error: any) {
    errorMessage.value = error.message || "Failed to register. Please try again.";
  }
};
</script>

<template>
  <div class="flex justify-center items-center min-h-screen bg-gray-100">
    <div class="bg-white p-8 rounded-lg shadow-md w-full max-w-md">
      <h2 class="text-2xl font-semibold mb-6">Register</h2>
      <form @submit.prevent="register">
        <div class="mb-4">
          <label for="role" class="block text-gray-700">Role:</label>
          <select id="role" v-model="user.role" class="mt-1 p-2 w-full border rounded-lg">
            <option value="customer">Customer</option>
            <option value="admin">Admin</option>
          </select>
        </div>
        <div v-if="user.role === 'admin'" class="mb-4">
          <label for="secretKey" class="block text-gray-700">Secret Key:</label>
          <input
            type="text"
            id="secretKey"
            v-model="user.secretKey"
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>

        <div class="mb-4">
          <label for="username" class="block text-gray-700">Username:</label>
          <input
            type="text"
            id="username"
            v-model="user.userName"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <div class="mb-4">
          <label for="email" class="block text-gray-700">Email:</label>
          <input
            type="email"
            id="email"
            v-model="user.email"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <div class="mb-4">
          <label for="password" class="block text-gray-700">Password:</label>
          <input
            type="password"
            id="password"
            v-model="user.password"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <button type="submit" class="bg-green-500 text-white py-2 px-4 rounded-lg w-full">
          Register
        </button>
      </form>
      <div v-if="errorMessage" class="text-red-500 mt-4">{{ errorMessage }}</div>
    </div>
  </div>
</template>
