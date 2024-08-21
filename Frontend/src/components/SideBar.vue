<script setup lang="ts">
import { computed } from "vue";
import { TrashIcon, XMarkIcon } from "@heroicons/vue/24/solid";
import { ProductGetDTO } from "../models/ProductDtos";
import { useOrderStore } from "../stores/OrderStore";
import { TransitionChild,TransitionRoot,Dialog,DialogTitle,DialogPanel } from "@headlessui/vue";
const orderStore = useOrderStore();

const removeFromCart = (product: ProductGetDTO) => {
  orderStore.removeItem(product);
};

const checkout = () => {
  orderStore.checkout();
};

const toggleSidebar = () => {
  orderStore.toggleSidebar();
};

const totalPrice = computed((): string => {
  return Object.values(orderStore.cart)
    .reduce((total: number, item: any) => {
      return total + item.product.Price * item.quantity;
    }, 0)
    .toFixed(2);
});
</script>

<template>
  <TransitionRoot as="template" :show="orderStore.showSidebar">
    <Dialog class="relative z-10" @close="toggleSidebar">
      <TransitionChild
        as="template"
        enter="ease-in-out duration-500"
        enter-from="opacity-0"
        enter-to="opacity-100"
        leave="ease-in-out duration-500"
        leave-from="opacity-100"
        leave-to="opacity-0"
      >
        <div class="fixed inset-0 bg-orange-500 bg-opacity-75 transition-opacity" />
      </TransitionChild>

      <div class="fixed inset-0 overflow-hidden">
        <div class="absolute inset-0 overflow-hidden">
          <div class="pointer-events-none fixed inset-y-0 right-0 flex max-w-full pl-10">
            <TransitionChild
              as="template"
              enter="transform transition ease-in-out duration-500 sm:duration-700"
              enter-from="translate-x-full"
              enter-to="translate-x-0"
              leave="transform transition ease-in-out duration-500 sm:duration-700"
              leave-from="translate-x-0"
              leave-to="translate-x-full"
            >
              <DialogPanel class="pointer-events-auto w-screen max-w-md">
                <div class="flex h-full flex-col overflow-y-scroll bg-white shadow-xl">
                  <div class="flex-1 overflow-y-auto px-4 py-6 sm:px-6">
                    <div class="flex items-start justify-between">
                      <DialogTitle class="text-lg font-medium text-orange-900"
                        >Shopping cart</DialogTitle
                      >
                      <div class="ml-3 flex h-7 items-center">
                        <button
                          type="button"
                          class="relative -m-2 p-2 text-orange-400 hover:text-orange-500"
                          @click="toggleSidebar"
                        >
                          <span class="absolute -inset-0.5" />
                          <span class="sr-only">Close panel</span>
                          <XMarkIcon class="h-6 w-6" aria-hidden="true" />
                        </button>
                      </div>
                    </div>

                    <div class="mt-8">
                      <div class="flow-root">
                        <ul role="list" class="-my-6 divide-y divide-orange-200">
                          <li
                            v-for="(item, index) in orderStore.cart"
                            :key="index"
                            class="flex py-6"
                          >
                            <div
                              class="h-24 w-24 flex-shrink-0 overflow-hidden rounded-md border border-orange-200"
                            >
                              <img
                                :src="item.product.Image"
                                :alt="item.product.Name"
                                class="h-full w-full object-cover object-center"
                              />
                            </div>

                            <div class="ml-4 flex flex-1 flex-col">
                              <div>
                                <div
                                  class="flex justify-between text-base font-medium text-orange-900"
                                >
                                  <h3>{{ item.product.Name }}</h3>
                                  <p class="ml-4">${{ item.product.Price.toFixed(2) }}</p>
                                </div>
                              </div>
                              <div class="flex flex-1 items-end justify-between text-sm">
                                <p class="text-orange-500">Qty {{ item.quantity }}</p>

                                <div class="flex">
                                  <button
                                    type="button"
                                    class="font-medium text-red-600 hover:text-orange-500"
                                    @click="removeFromCart(item.product)"
                                  >
                                    Remove
                                  </button>
                                </div>
                              </div>
                            </div>
                          </li>
                        </ul>
                      </div>
                    </div>
                  </div>

                  <div class="border-t border-orange-200 px-4 py-6 sm:px-6">
                    <div class="flex justify-between text-base font-medium text-orange-900">
                      <p>Subtotal</p>
                      <p>${{ totalPrice }}</p>
                    </div>
                    <p class="mt-0.5 text-sm text-orange-500">
                      Shipping and taxes calculated at checkout.
                    </p>
                    <div class="mt-6">
                      <RouterLink
                      v-if="orderStore.cart.length >= 1"
                      to="/order-confirmation"  
                      class="flex items-center justify-center rounded-md border border-transparent bg-green-600 px-6 py-3 text-base font-medium text-white shadow-sm hover:bg-orange-700"

                      >
                        Checkout
                      </RouterLink>
                    </div>
                    <div
                      class="mt-6 flex justify-center text-center text-sm text-orange-500"
                    >
                      <p>
                        or
                        <button
                          type="button"
                          class="font-medium text-green-600 hover:text-orange-500"
                          @click="toggleSidebar"
                        >
                          Continue Shopping<span aria-hidden="true"> &rarr;</span>
                        </button>
                      </p>
                    </div>
                  </div>
                </div>
              </DialogPanel>
            </TransitionChild>
          </div>
        </div>
      </div>
    </Dialog>
  </TransitionRoot>
</template>
