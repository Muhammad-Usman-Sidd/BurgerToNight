<script setup>
defineProps({
  toggle,
  cart,
});
const removeItem=(name){
        delete this.cart[name];
    },
const checkout=()=> {
    this.pastOrders.push(...Object.entries(this.cart).map(([name, quantity]) => {
        const product = this.inventory.find(p => p.name === name);
        return {
            name,
            quantity,
            price: product.price.,
            image: product.image
        };
    }));
    cart = {};
    toggleSidebar();
}
const getPrice = (name) => {
  const product = this.inventory.find((p) => p.name === name);
  return product ? product.price.USD : 0;
};
const getIcon = (name) => {
  const product = this.inventory.find((p) => p.name === name);
  return product ? product.icon : "carrot";
};
const calculateTotal = () => {
  return Object.entries(this.cart).reduce((acc, [name, quantity]) => {
    return acc + quantity * this.getPrice(name);
  }, 0);
};
</script>
<template>
  <aside
    class="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50 z-50"
  >
    <div class="bg-white w-11/12 md:w-1/2 lg:w-1/3 p-4 rounded-lg shadow-lg">
      <h1 class="flex justify-between items-center text-xl font-bold mb-4">
        <span>Cart</span>
        <button @click="toggle" class="text-red-500 text-2xl">&times;</button>
      </h1>

      <div class="overflow-auto">
        <table class="w-full text-left border-collapse">
          <thead>
            <tr>
              <th><span class="sr-only">Product Image</span></th>
              <th>Product</th>
              <th>Price</th>
              <th>Qty</th>
              <th>Total</th>
              <th><span class="sr-only">Actions</span></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(quantity, key, index) in cart" :key="index" class="border-b">
              <td class="py-2"><i :class="`icofont-${getIcon(key)} icofont-3x`"></i></td>
              <td class="py-2">{{ key }}</td>
              <td class="py-2">${{ getPrice(key).toFixed(2) }}</td>
              <td class="py-2 text-center">{{ quantity }}</td>
              <td class="py-2">${{ (getPrice(key) * quantity).toFixed(2) }}</td>
              <td class="py-2 text-center">
                <button @click="remove(key)" class="text-red-500 hover:text-red-700">
                  &times;
                </button>
              </td>
            </tr>
          </tbody>
        </table>

        <p class="text-center mt-4" v-if="!Object.keys(cart).length">
          <em>No items in cart</em>
        </p>
        <div
          class="flex justify-between items-center mt-4"
          v-if="Object.keys(cart).length"
        >
          <span class="font-bold">Total: ${{ calculateTotal().toFixed(2) }}</span>
          <button
            @click="checkout"
            class="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-700"
          >
            Checkout
          </button>
        </div>
      </div>
    </div>
  </aside>
</template>
