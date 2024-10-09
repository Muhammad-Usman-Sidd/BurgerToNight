import BaseService from "./BaseService";
import { APIResponse } from "../models/APIResult";
import { ProductCreateUpdateDTO, ProductGetDTO } from "../models/ProductDtos";

export interface IProductService {
  createProduct(
    dto: ProductCreateUpdateDTO
  ): Promise<APIResponse<ProductGetDTO>>;
  deleteProduct(id: number): Promise<APIResponse<null>>;
  getAllProducts(
    pageIndex: number,
    pageSize: number,
    searchQuery: string
  ): Promise<APIResponse<ProductGetDTO[]>>;
  getProduct(id: number): Promise<APIResponse<ProductGetDTO>>;
  updateProduct(
    dto: ProductCreateUpdateDTO
  ): Promise<APIResponse<ProductGetDTO>>;
}

class ProductService extends BaseService implements IProductService {
  constructor() {
    super(import.meta.env.VITE_API_URL);
  }

  async createProduct(
    dto: ProductCreateUpdateDTO
  ): Promise<APIResponse<ProductGetDTO>> {
    return this.sendRequest<ProductGetDTO>({
      Url: `/ProductAPI`,
      Method: "POST",
      Data: dto,
    });
  }

  async deleteProduct(id: number): Promise<APIResponse<null>> {
    return this.sendRequest<null>({
      Url: `/ProductAPI/${id}`,
      Method: "DELETE",
    });
  }

  async getAllProducts(
    pageIndex: number,
    pageSize: number,
    searchQuery: string
  ): Promise<APIResponse<ProductGetDTO[]>> {
    return this.sendRequest<ProductGetDTO[]>({
      Url: `/ProductAPI?pageNumber=${pageIndex}&pageSize=${pageSize}&searchQuery=${encodeURIComponent(
        searchQuery
      )}`,
      Method: "GET",
    });
  }

  async getProduct(id: number): Promise<APIResponse<ProductGetDTO>> {
    return this.sendRequest<ProductGetDTO>({
      Url: `/ProductAPI/${id}`,
      Method: "GET",
    });
  }

  async updateProduct(
    dto: ProductCreateUpdateDTO
  ): Promise<APIResponse<ProductGetDTO>> {
    return this.sendRequest<ProductGetDTO>({
      Url: `/ProductAPI/${dto.Id}`,
      Method: "PUT",
      Data: dto,
    });
  }
  async getTopProduct(topCount: number): Promise<APIResponse<ProductGetDTO[]>> {
    return this.sendRequest<ProductGetDTO[]>({
      Url: `/ProductAPI/top-products/${topCount}`,
      Method: "GET",
    });
  }
}

export default new ProductService();
