import BaseService from './BaseService';
import { APIResponse } from '../models/APIResult';
import { CategoryGetDTO, CategoryCreateDTO, CategoryUpdateDTO } from '../models/CategoryDtos';

export interface ICategoryService {
  createCategory(dto: CategoryCreateDTO): Promise<APIResponse<CategoryGetDTO>>;
  deleteCategory(id: number): Promise<APIResponse<null>>;
  getAllCategories(): Promise<APIResponse<CategoryGetDTO[]>>;
  updateCategory(dto:CategoryUpdateDTO):Promise<APIResponse<null>>;
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
  async updateCategory(dto: CategoryUpdateDTO): Promise<APIResponse<null>> {
    return this.sendRequest<null>({
      Url: `/CategoryAPI/${dto.Id}`,
      Method: 'PUT',
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
  async getCategory(id: number): Promise<APIResponse<CategoryGetDTO>> {
    return this.sendRequest<CategoryGetDTO>({
      Url: `/CategoryAPI/${id}`,
      Method: 'GET'
    });
  }
}
export default new CategoryService();