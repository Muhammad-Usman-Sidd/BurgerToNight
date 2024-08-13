import BaseService from './BaseService';
import { APIResponse } from '../models/APIResult';
import { CategoryGetDTO, CategoryCreateDTO } from '../models/CategoryDtos';

export interface ICategoryService {
  createCategory(dto: CategoryCreateDTO): Promise<APIResponse<CategoryGetDTO>>;
  deleteCategory(id: number): Promise<APIResponse<null>>;
  getAllCategories(): Promise<APIResponse<CategoryGetDTO[]>>;
}

class CategoryService extends BaseService implements ICategoryService {
  constructor() {
    super(import.meta.env.VITE_API_URL);
  }

  async createCategory(dto: CategoryCreateDTO): Promise<APIResponse<CategoryGetDTO>> {
    return this.sendRequest<CategoryGetDTO>({
      Url: `/CategoryAPI`,
      Method: 'POST',
      Data: dto,
    });
  }

  async deleteCategory(id: number): Promise<APIResponse<null>> {
    return this.sendRequest<null>({
      Url: `/CategoryAPI/${id}`,
      Method: 'DELETE',
    });
  }

  async getAllCategories(): Promise<APIResponse<CategoryGetDTO[]>> {
    return this.sendRequest<CategoryGetDTO[]>({
      Url: `/CategoryAPI`,
      Method: 'GET',
    });
  }
}
export default new CategoryService();