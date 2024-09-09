<script setup lang="ts">
import { defineProps } from "vue";
import HeroPic from "../assets/img/hero.jpg";

interface Props {
  title: string;
  subtitle: string;
}

const props = defineProps<Props>();
</script>

<template>
  <section class="relative py-20 md:py-20 lg:py-36 xl:py-48 2xl:py-64">
    <img
      :src="HeroPic"
      alt="Hero Image"
      class="absolute inset-0 w-full h-full object-cover -z-10"
    />

    <div class="absolute inset-0 bg-black opacity-50 -z-10"></div>

    <div
      class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 flex flex-col items-center relative z-10"
    >
      <div class="text-center">
        <h1
          class="text-3xl sm:text-4xl md:text-5xl lg:text-6xl xl:text-7xl font-extrabold text-white shadow-lg"
        >
          {{ props.title }}
        </h1>
        <p
          class="my-4 text-base sm:text-lg md:text-xl lg:text-2xl text-white shadow-md"
        >
          {{ props.subtitle }}
        </p>
      </div>
    </div>
  </section>
</template>

<style scoped>
@media (min-width: 640px) {
  .text-base {
    font-size: 1rem;
  }
}

@media (min-width: 768px) {
  .text-lg {
    font-size: 1.125rem;
  }
}

@media (min-width: 1024px) {
  .text-xl {
    font-size: 1.25rem;
  }
}

@media (min-width: 1280px) {
  .text-2xl {
    font-size: 1.5rem;
  }
}
</style>
