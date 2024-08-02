import { defineStore } from 'pinia';

export const useAuthStore = defineStore('auth', {
  state: () => ({
    isLoggedIn: false,
    token: '',
  }),
  actions: {
    login(token: string) {
      this.isLoggedIn = true;
      this.token = token;
    },
    logout() {
      this.isLoggedIn = false;
      this.token = '';
    },
  },
});

export default useAuthStore;
