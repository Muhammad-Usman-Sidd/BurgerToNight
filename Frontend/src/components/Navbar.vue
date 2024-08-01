<script setup lang="ts">
import logo from "../assets/img/logo.png";
import { useBurgerStore } from "../stores/ProductStore";
import SideBar from "./SideBar.vue";
import type { RouteLocationNormalizedLoaded } from "vue-router";
import { useRoute } from "vue-router";
import {
  ShoppingCartIcon,
  HomeIcon,
  ListBulletIcon,
  PlusCircleIcon,
  TagIcon,
  InboxStackIcon,
} from "@heroicons/vue/24/solid";

const isActiveLink = (routePath: string): boolean => {
  const route: RouteLocationNormalizedLoaded = useRoute();
  return route.path === routePath;
};

const store = useBurgerStore();
</script>

<template>
  <nav class="bg-orange-700 border-b border-orange-500">
    <div class="mx-auto max-w-7xl px-2 sm:px-6 lg:px-8">
      <div class="flex h-20 items-center justify-between">
        <div
          class="flex flex-1 items-center justify-center md:items-stretch md:justify-start"
        >
          <!-- Logo -->
          <RouterLink class="flex flex-shrink-0 items-center mr-4" to="/">
            <img class="h-10 w-auto" :src="logo" alt="Vue Burgers" />
            <span class="hidden md:block text-white text-2xl font-bold ml-2">
              Burger To Night
            </span>
          </RouterLink>
          <div class="md:ml-auto">
            <div class="flex space-x-2">
              <RouterLink
                to="/"
                :class="[
                  isActiveLink('/')
                    ? 'bg-orange-900'
                    : 'hover:bg-gray-900 hover:text-white',
                  'text-white',
                  'rounded-md',
                  'px-3',
                  'py-2',
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
                  'text-white',
                  'rounded-md',
                  'px-3',
                  'py-2',
                ]"
              >
                <ListBulletIcon class="h-5 w-5 inline-block mr-1" />
                Burgers
              </RouterLink>
              <RouterLink
                to="/add-burgers"
                :class="[
                  isActiveLink('/add-burgers')
                    ? 'bg-orange-900'
                    : 'hover:bg-gray-900 hover:text-white',
                  'text-white',
                  'rounded-md',
                  'px-3',
                  'py-2',
                ]"
              >
                <PlusCircleIcon class="h-5 w-5 inline-block mr-1" />
                Add Burgers
              </RouterLink>
              <RouterLink
                to="/categories"
                :class="[
                  isActiveLink('/categories')
                    ? 'bg-orange-900'
                    : 'hover:bg-gray-900 hover:text-white',
                  'text-white',
                  'rounded-md',
                  'px-3',
                  'py-2',
                ]"
              >
                <TagIcon class="h-5 w-5 inline-block mr-1" />
                Categories
              </RouterLink>
              <RouterLink
                to="/past-orders"
                :class="[
                  isActiveLink('/past-orders')
                    ? 'bg-orange-900'
                    : 'hover:bg-gray-900 hover:text-white',
                  'text-white',
                  'rounded-md',
                  'px-3',
                  'py-2',
                ]"
              >
                <InboxStackIcon class="h-5 w-5 inline-block mr-1" />
                Past Orders
              </RouterLink>
              <RouterLink to="/login">
                <button
                  class="px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-700"
                >
                  Login
                </button>
              </RouterLink>
              <RouterLink to="/register">
                <button
                  class="px-4 py-2 bg-green-500 text-white rounded hover:bg-green-700"
                >
                  Register
                </button>
              </RouterLink>
            </div>
          </div>
        </div>
        <button @click="store.toggleSidebar" class="p-2 text-white hover:text-gray-300">
          <ShoppingCartIcon class="h-6 w-6" />
        </button>
      </div>
    </div>
    <SideBar />
  </nav>
</template>
