import { defineStore } from 'pinia';
import { ResetPasswordDTO, LoginResponseDTO, RegistrationRequestDTO, LoginDTO } from '../models/AuthDtos';
import AuthService from '../services/AuthService';
import { APIResponse } from '../models/APIResult';

const authService = new AuthService();

export const useAuthStore = defineStore('auth', {
  state: () => ({
    isLoggedIn: false,
    user: {
      id: '',
      name: '',
      phoneNumber: '',
      address: ''
    } as any,
    token: localStorage.getItem('JWT token') || '',
    role: localStorage.getItem('Role') || '',
    showDropdownButtons: false
  }),
  actions: {
    async login(dto: LoginDTO) {
      try {
        const response: APIResponse<LoginResponseDTO> = await authService.login(dto);
        if (response.IsSuccess) {
          this.isLoggedIn = true;
          this.token = response.Result.Token;
          this.role = response.Result.Role;
          this.user.id = response.Result.User.Id;
          this.user.name = response.Result.User.Name;
          this.user.phoneNumber = response.Result.User.PhoneNumber;
          this.user.address = response.Result.User.Address;

          localStorage.setItem('JWT token', this.token);
          localStorage.setItem('Role', this.role);

          console.log(this.user);
        } else {
          throw new Error(response.ErrorMessages.join(', '));
        }
      } catch (error: any) {
        throw new Error(error.message || 'Failed to login. Please try again.');
      }
    },
    logout() {
      this.isLoggedIn = false;
      this.token = '';
      this.role = '';
      this.user = {};

      localStorage.removeItem('JWT token');
      localStorage.removeItem('Role');

      console.log("Logout successful");
    },
    async register(dto: RegistrationRequestDTO) {
      try {
        const response: APIResponse<any> = await authService.register(dto);
        console.log(response);
      } catch (error: any) {
        throw new Error(error.message || 'Failed to register. Please try again.');
      }
    },
    async resetPassword(dto: ResetPasswordDTO) {
      try {
        const response: APIResponse<ResetPasswordDTO> = await authService.resetPassword(dto);
        if (!response.IsSuccess) {
          throw new Error('Error resetting password');
        }
      } catch (error: any) {
        throw new Error(error.message || 'Failed to reset password. Please try again.');
      }
    },
    toggleDropdownButtons() {
      this.showDropdownButtons = !this.showDropdownButtons;
    },
    initializeStore() {
      const token = localStorage.getItem('JWT token');
      const role = localStorage.getItem('Role');
      if (token) {
        this.token = token;
        this.isLoggedIn = true;
        this.role = role || '';
      }
    }
  }
});
