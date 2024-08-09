<script setup lang="ts">
import logo from "../assets/img/logo.png";
import { useRoute } from "vue-router";
import {
  HomeIcon,
  ListBulletIcon,
  PlusCircleIcon,
  TagIcon,
  InboxStackIcon,
  Bars3Icon,
} from "@heroicons/vue/24/solid";
import SideBar from "./SideBar.vue";
import AuthButtons from "./AuthButtons.vue";
import { useAuthStore } from "../stores/AuthStore";
import { ref } from "vue";

const authStore = useAuthStore();
const route = useRoute();

const isActiveLink = (routePath: string): boolean => {
  return route.path === routePath;
};

const isMenuOpen = ref(false); // State for mobile menu
</script>

<template>
  <nav class="bg-orange-700 border-b border-orange-500">
    <div class="mx-auto max-w-7xl px-2 sm:px-6 lg:px-8">
      <div class="flex h-20 items-center justify-between">
        <!-- Left Section: Logo -->
        <div class="flex items-center">
          <RouterLink class="flex items-center" to="/">
            <img class="h-10 w-auto" :src="logo" alt="Vue Burgers" />
            <span class="hidden md:block text-white text-2xl font-bold ml-2">
              Burger To Night
            </span>
          </RouterLink>
        </div>

        <!-- Middle Section: Desktop Menu Links -->
        <div class="hidden md:flex space-x-2">
          <RouterLink
            to="/"
            :class="[
              isActiveLink('/')
                ? 'bg-orange-900'
                : 'hover:bg-gray-900 hover:text-white',
              'text-white rounded-md px-3 py-2',
            ]"
          >
            <HomeIcon class="h-5 w-5 inline-block mr-1" />
            Home
          </RouterLink>
          <RouterLink
            to="/burgers"
            :class="[
              isActiveLink('/burgers')
                ? 'bg-orange-900'
                : 'hover:bg-gray-900 hover:text-white',
              'text-white rounded-md px-3 py-2',
            ]"
          >
            <ListBulletIcon class="h-5 w-5 inline-block mr-1" />
            Burgers
          </RouterLink>
          <RouterLink
          v-if="authStore.isLoggedIn && authStore.role ==='admin'"
            to="/add-burger"
            :class="[
              isActiveLink('/add-burger')
                ? 'bg-orange-900'
                : 'hover:bg-gray-900 hover:text-white',
              'text-white rounded-md px-3 py-2',
            ]"
          >
            <ListBulletIcon class="h-5 w-5 inline-block mr-1" />
            Add Burger
          </RouterLink>
          <RouterLink
          v-if="authStore.isLoggedIn"
            to="/categories"
            :class="[
              isActiveLink('/categories')
                ? 'bg-orange-900'
                : 'hover:bg-gray-900 hover:text-white',
              'text-white rounded-md px-3 py-2',
            ]"
          >
            <ListBulletIcon class="h-5 w-5 inline-block mr-1" />
            Categories
          </RouterLink>
          <RouterLink v-if="authStore.isLoggedIn && authStore.role==='customer'"
            to="/past-orders"
            :class="[
              isActiveLink('/past-orders')
                ? 'bg-orange-900'
                : 'hover:bg-gray-900 hover:text-white',
              'text-white rounded-md px-3 py-2',
            ]"
          >
            <InboxStackIcon class="h-5 w-5 inline-block mr-1" />
            Past Orders
          </RouterLink>
          <RouterLink v-if="authStore.isLoggedIn && authStore.role==='admin'"
            to="/orders"
            :class="[
              isActiveLink('/orders')
                ? 'bg-orange-900'
                : 'hover:bg-gray-900 hover:text-white',
              'text-white rounded-md px-3 py-2',
            ]"
          >
            <InboxStackIcon class="h-5 w-5 inline-block mr-1" />
            Orders
          </RouterLink>
          <!-- Add more links here -->
          <AuthButtons />
        </div>

        <!-- Right Section: Mobile Menu Button -->
        <div class="flex items-center">
          <button
            class="inline-flex items-center justify-center rounded-md p-2 text-white hover:bg-orange-600 focus:outline-none focus:ring-2 focus:ring-inset focus:ring-white md:hidden"
            @click="isMenuOpen = !isMenuOpen"
          >
            <Bars3Icon class="h-6 w-6" />
          </button>
        </div>
      </div>
    </div>

    <!-- Mobile Menu -->
    <div
      v-show="isMenuOpen"
      class="md:hidden"
    >
      <div class="px-2 pt-2 pb-3 space-y-1 sm:px-3">
        <RouterLink
          to="/"
          :class="[
            isActiveLink('/')
              ? 'bg-orange-900'
              : 'hover:bg-gray-900 hover:text-white',
            'block text-white rounded-md px-3 py-2 text-base font-medium',
          ]"
        >
          <HomeIcon class="h-5 w-5 inline-block mr-1" />
          Home
        </RouterLink>
        <RouterLink
          to="/burgers"
          :class="[
            isActiveLink('/burgers')
              ? 'bg-orange-900'
              : 'hover:bg-gray-900 hover:text-white',
            'block text-white rounded-md px-3 py-2 text-base font-medium',
          ]"
        >
          <ListBulletIcon class="h-5 w-5 inline-block mr-1" />
          Burgers
        </RouterLink>
        <!-- More mobile links go here -->
        <AuthButtons />
      </div>
    </div>

    <SideBar />
  </nav>
</template>
