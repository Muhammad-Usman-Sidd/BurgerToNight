<script lang="ts" setup>
import { ref } from "vue";
import { useAuthStore } from "../../stores/AuthStore";
import { useToast } from "vue-toastification";
import { ResetPasswordDTO } from "../../models/AuthDtos";

const authStore = useAuthStore();
const toast = useToast();
const errorMessage = ref<string | null>(null);

const createResetPasswordDTO = (): ResetPasswordDTO => ({
  UserId: authStore.user.id,
  CurrentPassword: "",
  NewPassword: "",
  ConfirmPassword: "",
});

const user = ref<ResetPasswordDTO>(createResetPasswordDTO());

const resetPassword = async () => {
  try {
    await authStore.resetPassword(user.value);
    user.value = createResetPasswordDTO();
    toast.success("Password has been reset");
  } catch (error: any) {
    errorMessage.value = error.message;
    console.error("Error resetting the password", error);
  }
};
</script>

<template>
  <div class="flex justify-center items-center min-h-screen bg-gray-100">
    <div class="bg-white p-8 rounded-lg shadow-md w-full max-w-md">
      <h2 class="text-2xl font-semibold mb-6">Reset Password</h2>
      <form @submit.prevent="resetPassword">
        <div class="mb-4">
          <label for="currentPassword" class="block text-gray-700"
            >Current Password:</label
          >
          <input
            type="password"
            id="currentPassword"
            v-model="user.CurrentPassword"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <div class="mb-4">
          <label for="newPassword" class="block text-gray-700">New Password:</label>
          <input
            type="password"
            id="newPassword"
            v-model="user.NewPassword"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <div class="mb-4">
          <label for="confirmPassword" class="block text-gray-700"
            >Confirm Password:</label
          >
          <input
            type="password"
            id="confirmPassword"
            v-model="user.ConfirmPassword"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <button
          type="submit"
          class="bg-yellow-500 text-white py-2 px-4 rounded-lg w-full"
        >
          Reset Password
        </button>
      </form>
      <div v-if="errorMessage" class="text-red-500 mt-4">{{ errorMessage }}</div>
    </div>
  </div>
</template>
