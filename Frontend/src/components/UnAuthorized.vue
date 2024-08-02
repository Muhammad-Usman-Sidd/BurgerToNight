<template>
  <section class="flex items-center justify-center min-h-screen bg-gray-100">
    <div class="bg-white p-8 rounded shadow-md text-center">
      <div class="flex justify-center mb-4">
        <LockClosedIcon class="h-12 w-12 text-blue-500" />
      </div>
      <h2 class="text-xl font-semibold text-gray-700 mb-6">Sign in to Continue</h2>
      <RouterLink to="/login">
        <button
          class="flex items-center justify-center px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-700"
        >
          <ArrowRightOnRectangleIcon class="h-5 w-5 mr-2" />
          Login
        </button>
      </RouterLink>
    </div>
  </section>
</template>

<script setup>
import { RouterLink } from "vue-router";
import { LockClosedIcon, ArrowRightOnRectangleIcon } from "@heroicons/vue/24/solid";
</script>
