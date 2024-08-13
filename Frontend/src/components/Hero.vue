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
  <section class="relative py-20 mb-4">
    <img :src="HeroPic" alt="Hero Image" class="absolute inset-0 w-full h-full object-cover -z-10">

    <div class="absolute inset-0 bg-black opacity-50 -z-10"></div>

    <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 flex flex-col items-center relative z-10">
      <div class="text-center">
        <h1 class="text-4xl font-extrabold text-white shadow-lg sm:text-5xl md:text-6xl">
          {{ props.title }}
        </h1>
        <p class="my-4 text-xl text-white shadow-md">
          {{ props.subtitle }}
        </p>
      </div>
    </div>
  </section>
</template>
