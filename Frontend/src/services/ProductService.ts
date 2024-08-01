import BaseService from './BaseService';
import { APIResponse } from '../models/APIResult';
import { ProductGetDTO, ProductCreateDTO, ProductUpdateDTO } from '../models/ProductDtos';

const API_URL = import.meta.env.VITE_API_URL;

export interface IProductService {
  createProduct(dto: ProductCreateDTO, token: string): Promise<APIResponse<ProductGetDTO>>;
  deleteProduct(id: number, token: string): Promise<APIResponse<null>>;
  getAllProducts(pageIndex:number ,token: string): Promise<APIResponse<ProductGetDTO[]>>;
  getProduct(id: number, token: string): Promise<APIResponse<ProductGetDTO>>;
  updateProduct(dto: ProductUpdateDTO, token: string): Promise<APIResponse<null>>;
}

class ProductService extends BaseService implements IProductService {
  constructor() {
    super(API_URL); // Pass the base URL
  }

  async createProduct(dto: ProductCreateDTO, token: string): Promise<APIResponse<ProductGetDTO>> {
    return this.sendRequest<ProductGetDTO>({
      Url: `/ProductAPI`,
      Method: 'POST',
      Data: dto,
      Token: token
    });
  }

  async deleteProduct(id: number, token: string): Promise<APIResponse<null>> {
    return this.sendRequest<null>({
      Url: `/ProductAPI/${id}`,
      Method: 'DELETE',
      Token: token
    });
  }

  async getAllProducts(pageNumber: number): Promise<APIResponse<ProductGetDTO[]>> {
    return this.sendRequest<ProductGetDTO[]>({
      Url: `/ProductAPI?pageNumber=${pageNumber}&pageSize=3`,
      Method: 'GET',
    });
  }

  async getProduct(id: number, token: string): Promise<APIResponse<ProductGetDTO>> {
    return this.sendRequest<ProductGetDTO>({
      Url: `/ProductAPI/${id}`,
      Method: 'GET',
      Token: token
    });
  }

  async updateProduct(dto: ProductUpdateDTO, token: string): Promise<APIResponse<null>> {
    return this.sendRequest<null>({
      Url: `/ProductAPI/${dto.Id}`,
      Method: 'PUT',
      Data: dto,
      Token: token
    });
  }
}

export default new ProductService();
