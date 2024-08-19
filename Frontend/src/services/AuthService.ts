import BaseService from './BaseService';
import { APIResponse } from '../models/APIResult';
import { LoginDTO, RegistrationRequestDTO, ResetPasswordDTO } from '../models/AuthDtos';

interface IAuthService {
    login<T>(dto: LoginDTO): Promise<APIResponse<T>>;
    register<T>(dto: RegistrationRequestDTO): Promise<APIResponse<T>>;
    resetPassword<T>(dto: ResetPasswordDTO): Promise<APIResponse<T>>;
    getUserById<T>(Id: number): Promise<APIResponse<T>>;
}

class AuthService extends BaseService implements IAuthService {
    constructor() {
        super(import.meta.env.VITE_API_URL);
    }

    async login<T>(dto: LoginDTO): Promise<APIResponse<T>> {
        return this.sendRequest<T>({
            Url: '/AuthLogin',
            Method: 'POST',
            Data: dto
        });
    }

    async register<T>(dto: RegistrationRequestDTO): Promise<APIResponse<T>> {
        return this.sendRequest<T>({
            Url: '/AuthRegister',
            Method: 'POST',
            Data: dto
        });
    }

    async resetPassword<T>(dto: ResetPasswordDTO): Promise<APIResponse<T>> {
        return this.sendRequest<T>({
            Url: '/AuthResetPassword',
            Method: 'POST',
            Data: dto
        });
    }

    async getUserById<T>(Id: number): Promise<APIResponse<T>> {
        return this.sendRequest<T>({
            Url: `/user/${Id}`,
            Method: 'POST',
        });
    }
}

export default AuthService;
