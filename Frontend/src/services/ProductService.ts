import BaseService from './BaseService';
import { APIResponse } from '../models/APIResult';
import { ProductGetDTO, ProductCreateDTO, ProductUpdateDTO } from '../models/ProductDtos';

export interface IProductService {
  createProduct(dto: ProductCreateDTO): Promise<APIResponse<ProductGetDTO>>;
  deleteProduct(id: number): Promise<APIResponse<null>>;
  getAllProducts(pageIndex:number,pageSize:number): Promise<APIResponse<ProductGetDTO[]>>;
  getProduct(id: number): Promise<APIResponse<ProductGetDTO>>;
  updateProduct(dto: ProductUpdateDTO): Promise<APIResponse<null>>;
}

class ProductService extends BaseService implements IProductService {
  constructor() {
    super(import.meta.env.VITE_API_URL);
  }

  async createProduct(dto: ProductCreateDTO): Promise<APIResponse<ProductGetDTO>> {
    return this.sendRequest<ProductGetDTO>({
      Url: `/ProductAPI`,
      Method: 'POST',
      Data: dto,
    });
  }

  async deleteProduct(id: number): Promise<APIResponse<null>> {
    return this.sendRequest<null>({
      Url: `/ProductAPI/${id}`,
      Method: 'DELETE',
    });
  }

  async getAllProducts(pageIndex: number,pageSize:number): Promise<APIResponse<ProductGetDTO[]>> {
    return this.sendRequest<ProductGetDTO[]>({
      Url: `/ProductAPI?pageNumber=${pageIndex}&${pageSize}`,
      Method: 'GET'
    });
  }

  async getProduct(id: number): Promise<APIResponse<ProductGetDTO>> {
    return this.sendRequest<ProductGetDTO>({
      Url: `/ProductAPI/${id}`,
      Method: 'GET'
    });
  }

  async updateProduct(dto: ProductUpdateDTO): Promise<APIResponse<null>> {
    return this.sendRequest<null>({
      Url: `/ProductAPI/${dto.Id}`,
      Method: 'PUT',
      Data: dto,
    });
  }
}

export default new ProductService();
