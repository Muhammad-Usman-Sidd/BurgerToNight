<script setup lang="ts">
import { computed } from "vue";
import { useAuthStore } from "../../stores/AuthStore";
import { RouterLink } from "vue-router";
import { useRouter } from "vue-router";

const authStore = useAuthStore();
const isLoggedIn = computed(() => authStore.isLoggedIn);
const router = useRouter();

const logout = async () => {
  authStore.logout();
  router.push('/');
}
</script>

<template>
  <div class="relative">
    <div
      v-show="authStore.showDropdownButtons"
      @mouseleave="authStore.toggleDropdownButtons"
      class="absolute left-0 mt-2 w-48 bg-white shadow-lg rounded-md z-10"
    >
      <div class="flex flex-col space-y-1 p-2">
        <RouterLink v-if="!isLoggedIn" to="/login">
          <button class="w-full justify-center px-4 py-2 bg-orange-500 text-white rounded hover:bg-orange-700">
            Sign In
          </button>
        </RouterLink>
        <RouterLink v-if="!isLoggedIn" to="/register">
          <button class="w-full justify-center px-4 py-2 bg-green-500 text-white rounded hover:bg-green-700">
            Sign Up
          </button>
        </RouterLink>
        <RouterLink v-if="isLoggedIn" to="/reset-password">
          <button class="w-full justify-center px-4 py-2 bg-yellow-500 text-white rounded hover:bg-yellow-700">
            Reset Password
          </button>
        </RouterLink>
        <button
          v-if="isLoggedIn"
          @click="logout"
          class="w-full justify-center px-4 py-2 bg-red-500 text-white rounded hover:bg-red-700"
        >
          Logout
        </button>
      </div>
    </div>
  </div>
</template>
