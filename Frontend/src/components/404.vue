<script lang="ts" setup>
import { RouterLink } from "vue-router";
import { ExclamationTriangleIcon } from "@heroicons/vue/24/outline";
</script>

<template>
  <main
    class="grid min-h-full place-items-center bg-orange-100 px-6 py-24 sm:py-32 lg:px-8"
  >
    <div class="text-center">
      <div class="flex justify-center">
        <ExclamationTriangleIcon
          class="h-12 w-12 text-orange-600"
          aria-hidden="true"
        />
      </div>
      <p class="text-3xl font-semibold text-gray-600 mt-4">404</p>
      <h1
        class="mt-2 text-3xl font-bold tracking-tight text-orange-900 sm:text-5xl"
      >
        Page not found
      </h1>
      <p class="mt-6 text-base leading-7 text-orange-600">
        Sorry, we couldn’t find the page you’re looking for.
      </p>
      <div class="mt-10 flex items-center justify-center gap-x-6">
        <RouterLink
          to="/"
          class="rounded-md bg-gray-600 px-4 py-2 text-sm font-semibold text-white shadow-sm hover:bg-orange-600 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-orange-600 transition ease-in-out duration-150"
        >
          Go back home
        </RouterLink>
      </div>
    </div>
  </main>
</template>
