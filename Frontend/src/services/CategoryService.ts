import BaseService from './BaseService';
import { APIResponse } from '../models/APIResult';
import { CategoryGetDTO, CategoryCreateDTO } from '../models/CategoryDtos';

const API_URL = import.meta.env.VITE_API_URL;

export interface ICategoryService {
  createCategory(dto: CategoryCreateDTO, token: string): Promise<APIResponse<CategoryGetDTO>>;
  deleteCategory(id: number, token: string): Promise<APIResponse<null>>;
  getAllCategories(): Promise<APIResponse<CategoryGetDTO[]>>;
}

class CategoryService extends BaseService implements ICategoryService {
  constructor() {
    super(API_URL);
  }

  async createCategory(dto: CategoryCreateDTO, token: string): Promise<APIResponse<CategoryGetDTO>> {
    return this.sendRequest<CategoryGetDTO>({
      Url: `/CategoryAPI`,
      Method: 'POST',
      Data: dto,
      Token: token
    });
  }

  async deleteCategory(id: number, token: string): Promise<APIResponse<null>> {
    return this.sendRequest<null>({
      Url: `/CategoryAPI/${id}`,
      Method: 'DELETE',
      Token: token
    });
  }

  async getAllCategories(): Promise<APIResponse<CategoryGetDTO[]>> {
    return this.sendRequest<CategoryGetDTO[]>({
      Url: `/CategoryAPI`,
      Method: 'GET'
    });
  }
}
export default new CategoryService();