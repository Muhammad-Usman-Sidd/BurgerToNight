import BaseService from "./BaseService";
import { APIResponse } from "../models/APIResult";
import {
  LoginDTO,
  LoginResponseDTO,
  RegistrationRequestDTO,
  ResetPasswordDTO,
  UserDTO,
} from "../models/AuthDtos";

interface IAuthService {
  login(dto: LoginDTO): Promise<APIResponse<LoginResponseDTO>>;
  register(dto: RegistrationRequestDTO): Promise<APIResponse<UserDTO>>;
  resetPassword<T>(dto: ResetPasswordDTO): Promise<APIResponse<T>>;
  getUserById(Id: string): Promise<APIResponse<UserDTO>>;
  getTopCustomers(): Promise<APIResponse<UserDTO[]>>;
}

class AuthService extends BaseService implements IAuthService {
  constructor() {
    super(import.meta.env.VITE_API_URL);
  }

  async login(dto: LoginDTO): Promise<APIResponse<LoginResponseDTO>> {
    return this.sendRequest<LoginResponseDTO>({
      Url: "/AuthLogin",
      Method: "POST",
      Data: dto,
    });
  }

  async register(dto: RegistrationRequestDTO): Promise<APIResponse<UserDTO>> {
    return this.sendRequest<UserDTO>({
      Url: "/AuthRegister",
      Method: "POST",
      Data: dto,
    });
  }

  async resetPassword<T>(dto: ResetPasswordDTO): Promise<APIResponse<T>> {
    return this.sendRequest<T>({
      Url: "/AuthResetPassword",
      Method: "POST",
      Data: dto,
    });
  }

  async getUserById(Id: string): Promise<APIResponse<UserDTO>> {
    return this.sendRequest<UserDTO>({
      Url: `/user/${Id}`,
      Method: "GET",
    });
  }
  async getAllUsers(): Promise<APIResponse<UserDTO[]>> {
    return this.sendRequest<UserDTO[]>({
      Url: `/users`,
      Method: "GET",
    });
  }
  async getTopCustomers(): Promise<APIResponse<UserDTO[]>> {
    return this.sendRequest<UserDTO[]>({
      Url: `/users/top-customers`,
      Method: "GET",
    });
  }
}

export default new AuthService();
