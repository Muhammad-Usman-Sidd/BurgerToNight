<script setup lang="ts">
import logo from "../assets/img/logo.png";
import { useRoute } from "vue-router";
import {
  HomeIcon,
  ListBulletIcon,
  TagIcon,
  InboxStackIcon,
  Bars3Icon,
  Cog8ToothIcon,
} from "@heroicons/vue/24/solid";
import { TransitionChild,TransitionRoot } from "@headlessui/vue";
import { useAuthStore } from "../stores/AuthStore";
import { ref } from "vue";
import AuthButtons from "./Auth/AuthButtons.vue";

const authStore = useAuthStore();
const route = useRoute();
const isActiveLink = (routePath: string): boolean => {
  return route.path === routePath;
};

const isMenuOpen = ref(false);
</script>

<template>
  <nav class="bg-orange-800 border-b border-orange-500 relative">
    <div class="mx-auto max-w-7xl px-2 sm:px-6 lg:px-8">
      <div class="flex h-20 items-center justify-between">
        <div class="flex items-center">
          <RouterLink class="flex absolute left-10 items-center" to="/">
            <img class="h-10 w-auto" :src="logo" alt="Vue Products" />
            <span class="hidden md:block text-white text-2xl font-bold ml-2">
              Bite Quest
            </span>
          </RouterLink>
        </div>

        <div class="hidden md:flex space-x-2">
          <RouterLink
            to="/"
            :class="[
              isActiveLink('/') ? 'bg-orange-900' : 'hover:bg-orange-900 hover:text-white',
              'text-white rounded-md px-3 py-2',
            ]"
          >
            <HomeIcon class="h-5 w-5 inline-block mr-1" />
            Home
          </RouterLink>
          <RouterLink
            to="/products"
            :class="[
              isActiveLink('/products')
                ? 'bg-orange-900'
                : 'hover:bg-orange-900 hover:text-white',
              'text-white rounded-md px-3 py-2',
            ]"
          >
            <ListBulletIcon class="h-5 w-5 inline-block mr-1" />
            Products
          </RouterLink>
          <RouterLink
            v-if="authStore.isLoggedIn"
            to="/categories"
            :class="[
              isActiveLink('/categories')
                ? 'bg-orange-900'
                : 'hover:bg-orange-900 hover:text-white',
              'text-white rounded-md px-3 py-2',
            ]"
          >
            <TagIcon class="h-5 w-5 inline-block mr-1" />
            Categories
          </RouterLink>
          <RouterLink
            v-if="authStore.isLoggedIn && authStore.role === 'customer'"
            to="/past-orders"
            :class="[
              isActiveLink('/past-orders')
                ? 'bg-orange-900'
                : 'hover:bg-orange-900 hover:text-white',
              'text-white rounded-md px-3 py-2',
            ]"
          >
            <InboxStackIcon class="h-5 w-5 inline-block mr-1" />
            Past Orders
          </RouterLink>
          <RouterLink
            v-if="authStore.isLoggedIn && authStore.role === 'admin'"
            to="/orders"
            :class="[
              isActiveLink('/orders')
                ? 'bg-orange-900'
                : 'hover:bg-orange-900 hover:text-white',
              'text-white rounded-md px-3 py-2',
            ]"
          >
            <InboxStackIcon class="h-5 w-5 inline-block mr-1" />
            Orders
          </RouterLink>
        </div>

        <div class="hidden md:flex items-center">
          <button
            @click="authStore.toggleDropdownButtons"
            class="text-white absolute right-10 flex items-center"
          >
            <Cog8ToothIcon class="h-6 w-6" />
          </button>
          <div
            v-if="authStore.showDropdownButtons"
            class="absolute right-10 mt-2 w-48 bg-white shadow-lg rounded-md z-10"
          >
            <AuthButtons />
          </div>
        </div>

        <!-- Mobile Menu Button -->
        <div class="flex items-center md:hidden">
          <button
            class="inline-flex items-center justify-center rounded-md p-2 text-white hover:bg-orange-600 focus:outline-none focus:ring-2 focus:ring-inset focus:ring-white"
            @click="isMenuOpen = !isMenuOpen"
          >
            <Bars3Icon class="h-6 w-6" />
          </button>
        </div>
      </div>
    </div>

    <!-- Mobile Menu -->
    <TransitionRoot as="template" :show="isMenuOpen">
      <TransitionChild
        as="div"
        enter="transform transition ease-in-out duration-500 sm:duration-700"
        enter-from="opacity-0 translate-x-[100%]"
        enter-to="opacity-100 translate-x-0"
        leave="transform transition ease-in-out duration-500 sm:duration-700"
        leave-from="opacity-100 translate-x-0"
        leave-to="opacity-0 translate-x-[100%]"
        class="fixed inset-0 top-20 bg-orange-700 z-50"
      >
        <div class="px-2 pt-2 pb-3 space-y-1 sm:px-3">
          <RouterLink
            to="/"
            @click="isMenuOpen = !isMenuOpen"
            :class="[
              isActiveLink('/') ? 'bg-orange-900' : 'hover:bg-orange-900 hover:text-white',
              'block text-white rounded-md px-3 py-2 text-base font-medium',
            ]"
          >
            <HomeIcon class="h-5 w-5 inline-block mr-1" />
            Home
          </RouterLink>
          <RouterLink
            to="/products"
            @click="isMenuOpen = !isMenuOpen"
            :class="[
              isActiveLink('/products')
                ? 'bg-orange-900'
                : 'hover:bg-orange-900 hover:text-white',
              'block text-white rounded-md px-3 py-2 text-base font-medium',
            ]"
          >
            <ListBulletIcon class="h-5 w-5 inline-block mr-1" />
            Products
          </RouterLink>
          <RouterLink
            v-if="authStore.isLoggedIn"
            @click="isMenuOpen = !isMenuOpen"
            to="/categories"
            :class="[
              isActiveLink('/categories')
                ? 'bg-orange-900'
                : 'hover:bg-orange-900 hover:text-white',
              'block text-white rounded-md px-3 py-2 text-base font-medium',
            ]"
          >
            <TagIcon class="h-5 w-5 inline-block mr-1" />
            Categories
          </RouterLink>
          <RouterLink
            v-if="authStore.isLoggedIn && authStore.role === 'admin'"
            to="/orders"
            @click="isMenuOpen = !isMenuOpen"
            :class="[
              isActiveLink('/orders')
                ? 'bg-orange-900'
                : 'hover:bg-orange-900 hover:text-white',
              'block text-white rounded-md px-3 py-2 text-base font-medium',
            ]"
          >
            <InboxStackIcon class="h-5 w-5 inline-block mr-1" />
            Orders
          </RouterLink>
          <RouterLink
            v-if="authStore.isLoggedIn && authStore.role === 'customer'"
            to="/past-orders"
            @click="isMenuOpen = !isMenuOpen"
            :class="[
              isActiveLink('/past-orders')
                ? 'bg-orange-900'
                : 'hover:bg-orange-900 hover:text-white',
              'block text-white rounded-md px-3 py-2 text-base font-medium',
            ]"
          >
            <InboxStackIcon class="h-5 w-5 inline-block mr-1" />
            Past Orders
          </RouterLink>
          <div class="block text-white rounded-md px-3 py-2 text-base font-medium">
            <button @click="authStore.toggleDropdownButtons">
              <Cog8ToothIcon class="h-5 w-5 inline-block mr-1" />
              Profile
            </button>
            <div
              v-if="authStore.showDropdownButtons"
              class="absolute mt-2 w-48 bg-white shadow-lg rounded-md z-10"
            >
              <AuthButtons />
            </div>
          </div>
        </div>
      </TransitionChild>
    </TransitionRoot>
  </nav>
</template>
