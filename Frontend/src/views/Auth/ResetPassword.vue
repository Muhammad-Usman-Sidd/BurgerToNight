<template>
  <div class="flex justify-center items-center min-h-screen bg-gray-100">
    <div class="bg-white p-8 rounded-lg shadow-md w-full max-w-md">
      <h2 class="text-2xl font-semibold mb-6">Reset Password</h2>
      <form @submit.prevent="resetPassword">
        <div class="mb-4">
          <label for="userId" class="block text-gray-700">User ID:</label>
          <input
            type="text"
            id="userId"
            v-model="resetPasswordRequest.userId"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <div class="mb-4">
          <label for="newPassword" class="block text-gray-700">New Password:</label>
          <input
            type="password"
            id="newPassword"
            v-model="resetPasswordRequest.newPassword"
            required
            class="mt-1 p-2 w-full border rounded-lg"
          />
        </div>
        <button
          type="submit"
          class="bg-yellow-500 text-white py-2 px-4 rounded-lg w-full"
        >
          Reset Password
        </button>
      </form>
      <div v-if="errorMessage" class="text-red-500 mt-4">{{ errorMessage }}</div>
    </div>
  </div>
</template>
