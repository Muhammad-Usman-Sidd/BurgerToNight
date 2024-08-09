<script setup lang="ts">
import { ref } from "vue";
import { useAuthStore } from "../stores/AuthStore";

const authStore = useAuthStore();
const isMenuOpen = ref(false); // State for settings menu

const toggleMenu = () => {
  isMenuOpen.value = !isMenuOpen.value;
};

const logout = () => {
  authStore.logout(); // Implement logout logic in AuthStore
};

const resetPassword = () => {
  // Implement password reset logic
};
</script>

<template>
  <div class="relative">
    <button
      @click="toggleMenu"
      class="p-2 text-white hover:text-gray-300 focus:outline-none"
      aria-label="Settings"
    >
      <svg
        class="h-6 w-6"
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        stroke="currentColor"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M12 8.5a3.5 3.5 0 11-7 0 3.5 3.5 0 017 0zM5 12a7 7 0 0114 0M7 14a5 5 0 0110 0"
        />
      </svg>
    </button>

    <!-- Settings Menu -->
    <div
      v-if="isMenuOpen"
      class="absolute right-0 w-48 mt-2 bg-white rounded-md shadow-lg ring-1 ring-black ring-opacity-5"
    >
      <div class="py-1">
        <button
          @click="logout"
          class="block w-full text-left px-4 py-2 text-sm text-gray-700 hover:bg-gray-100"
        >
          Logout
        </button>
        <button
          @click="resetPassword"
          class="block w-full text-left px-4 py-2 text-sm text-gray-700 hover:bg-gray-100"
        >
          Reset Password
        </button>
      </div>
    </div>
  </div>
</template>
