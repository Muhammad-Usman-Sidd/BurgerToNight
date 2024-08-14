<script setup lang="ts">
import { LockClosedIcon, ArrowRightIcon } from "@heroicons/vue/24/solid";
import { useAuthStore } from "../../stores/AuthStore";
const authStore=useAuthStore();
</script>
<template>
  <section
  v-if="!authStore.isLoggedIn"
    class="flex items-center justify-center min-h-screen bg-gradient-to-r from-gray-200 to-gray-400"
  >
    <div class="bg-white p-12 rounded-xl shadow-lg text-center">
      <div class="flex justify-center mb-6">
        <LockClosedIcon class="h-16 w-16 text-blue-600" />
      </div>
      <h2 class="text-2xl font-bold text-gray-800 mb-8">Sign in to Continue</h2>
      <RouterLink to="/login">
        <button
          class="flex items-center justify-center px-6 py-3 bg-blue-600 text-white rounded-lg text-lg font-medium hover:bg-blue-800 transition-colors duration-300"
        >
          <ArrowRightIcon class="h-6 w-6 mr-3" />
          Login
        </button>
      </RouterLink>
    </div>
  </section>
</template>
