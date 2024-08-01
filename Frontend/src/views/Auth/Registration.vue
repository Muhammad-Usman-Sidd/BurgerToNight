<script setup lang="ts">
import { ref } from "vue";
import AuthService from "../../services/AuthService";
import { useToast } from "vue-toastification";
import { RegistrationRequestDTO } from "../../models/AuthDtos";

const authService = new AuthService(import.meta.env.VITE_API_URL);
const registerRequest = ref<RegistrationRequestDTO>({
  userName: "",
  email: "",
  password: "",
  name: "",
  role: "customer",
});
const errorMessage = ref<string>("");

const register = async () => {
  try {
    const response = await authService.register({
      userName: registerRequest.value.userName,
      email: registerRequest.value.email,
      password: registerRequest.value.password,
      name: registerRequest.value.name,
      role: registerRequest.value.role,
    });

    if (response.IsSuccess) {
      console.log("Registration successful:", response.Result);
      registerRequest.value = {
        userName: "",
        email: "",
        password: "",
        name: "",
        role: "customer",
      };
    } else {
      errorMessage.value = response.ErrorMessages.join(", ");
    }
  } catch (error) {
    errorMessage.value = "Failed to register. Please try again.";
  }
};
</script>

<template>
  <div class="flex justify-center items-center min-h-screen bg-gray-100">
    <div class="bg-white p-8 rounded-lg shadow-md w-full max-w-md">
      <h2 class="text-2xl font-semibold mb-6">Register</h2>
      <form @submit.prevent="register">
        <div class="mb-4">
          <label for="username" class="block text-gray-700">Username:</label>
          <input
            type="text"
            id="username"
            v-model="registerRequest.userName"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <div class="mb-4">
          <label for="email" class="block text-gray-700">Email:</label>
          <input
            type="email"
            id="email"
            v-model="registerRequest.email"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <div class="mb-4">
          <label for="password" class="block text-gray-700">Password:</label>
          <input
            type="password"
            id="password"
            v-model="registerRequest.password"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <div class="mb-4">
          <label for="name" class="block text-gray-700">Name:</label>
          <input
            type="text"
            id="name"
            v-model="registerRequest.name"
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
