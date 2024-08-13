import axios, { AxiosInstance, AxiosRequestConfig, AxiosResponse } from 'axios';
import { APIRequest, APIResponse } from '../models/APIResult';

class BaseService {
  private axiosInstance: AxiosInstance;

  constructor(baseURL: string) {
    this.axiosInstance = axios.create({ baseURL });

    this.axiosInstance.interceptors.request.use(
      (config: any) => {
        const token = localStorage.getItem('JWT token');
        if (token) {
          config.headers = {
            ...config.headers,
            Authorization: `Bearer ${token}`,
          };
        }
        return config;
      },
      (error) => {
        return Promise.reject(error);
      }
    );
  }

  protected async sendRequest<T>(apiRequest: APIRequest): Promise<APIResponse<T>> {
    try {
      const config: AxiosRequestConfig = {
        method: apiRequest.Method,
        url: apiRequest.Url,
        data: apiRequest.Data,
        headers: apiRequest.Token ? { Authorization: `Bearer ${apiRequest.Token}` } : {}
      };
      const response: AxiosResponse<APIResponse<T>> = await this.axiosInstance(config);
      return response.data;
    } catch (e :any) {
      const apiResponse: APIResponse<T> = {
        Result: {} as T,
        IsSuccess: false,
        ErrorMessages: [e.message],
        StatusCode: e.response?.status || 500
      };
      return apiResponse;
    }
  }

  // Method to store the token
  public setToken(token: string) {
    localStorage.setItem('jwtToken', token);
  }

  // Method to remove the token (for logout)
  public clearToken() {
    localStorage.removeItem('jwtToken');
  }
}

export default BaseService;
