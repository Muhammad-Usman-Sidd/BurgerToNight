<script setup lang="ts">
import { ref } from "vue";
import { useAuthStore } from "../../stores/AuthStore";
import { RegistrationRequestDTO } from "../../models/AuthDtos";
import { useToast } from "vue-toastification";
import { useRouter } from "vue-router";
const router = useRouter();
const toast = useToast();
const authStore = useAuthStore();
const createUser = (): RegistrationRequestDTO => ({
  UserName: "",
  Email: "",
  PhoneNumber: "",
  Address: "",
  Password: "",
  Role: "",
  SecretKey: "",
});
const registerUser = ref<RegistrationRequestDTO>(createUser());

const register = async () => {
  try {
    await authStore.register(registerUser.value);
    toast.success(`Account created successfully login to continue`);
    registerUser.value = createUser();
    router.push("/login");
  } catch (error: any) {
    console.log("Error:" + error);
  }
};
</script>

<template>
  <div
    v-if="!authStore.isLoggedIn"
    class="flex justify-center items-center min-h-screen bg-gray-100"
  >
    <div class="bg-white p-8 rounded-lg shadow-md w-full max-w-md">
      <h2 class="text-2xl font-semibold mb-6">Register</h2>
      <form @submit.prevent="register">
        <div class="mb-4">
          <label for="role" class="block text-gray-700">Role:</label>
          <select
            id="role"
            v-model="registerUser.Role"
            class="mt-1 p-2 w-full border rounded-lg"
          >
            <option value="customer">Customer</option>
            <option value="admin">Admin</option>
          </select>
        </div>
        <div v-if="registerUser.Role === 'admin'" class="mb-4">
          <label for="secretKey" class="block text-gray-700">Secret Key:</label>
          <input
            type="text"
            id="secretKey"
            v-model="registerUser.SecretKey"
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>

        <div class="mb-4">
          <label for="username" class="block text-gray-700">Username:</label>
          <input
            type="text"
            id="username"
            v-model="registerUser.UserName"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>

        <div class="mb-4">
          <label for="phoneNumber" class="block text-gray-700">PhoneNumber:</label>
          <input
            type="text"
            id="phoneNumber"
            v-model="registerUser.PhoneNumber"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <div class="mb-4">
          <label for="address" class="block text-gray-700">Address:</label>
          <input
            type="text"
            id="address"
            v-model="registerUser.Address"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <div class="mb-4">
          <label for="email" class="block text-gray-700">Email:</label>
          <input
            type="email"
            id="email"
            v-model="registerUser.Email"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <div class="mb-4">
          <label for="password" class="block text-gray-700">Password:</label>
          <input
            type="password"
            id="password"
            v-model="registerUser.Password"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <button type="submit" class="bg-green-500 text-white py-2 px-4 rounded-lg w-full">
          Register
        </button>
      </form>
    </div>
  </div>
</template>
