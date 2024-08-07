import BaseService from './BaseService';
import { APIResponse } from '../models/APIResult';
import { OrderHeaderGetDTO,OrderHeaderCreateDTO,OrderHeaderUpdateDTO } from '../models/OrderHeaderDtos';

export interface IOrderService {
  getUserOrders(userId: string, token: string): Promise<APIResponse<OrderHeaderGetDTO[]>>;
  deleteOrder(orderId: number, token: string): Promise<APIResponse<null>>;
  placeOrder(dto:OrderHeaderCreateDTO ,token: string): Promise<APIResponse<OrderHeaderGetDTO>>;
  updateOrder(dto:OrderHeaderUpdateDTO, token: string): Promise<APIResponse<null>>;
}

class OrderService extends BaseService implements IOrderService {
  constructor() {
    super(import.meta.env.VITE_API_URL);
  }

  async getUserOrders(userId: string, token: string): Promise<APIResponse<OrderHeaderGetDTO[]>> {
    return this.sendRequest<OrderHeaderGetDTO[]>({
      Method: 'GET',
      Url: `orders/${userId}`,
      Token: token
    });
  }

  async deleteOrder(orderId: number, token: string): Promise<APIResponse<null>> {
    return this.sendRequest<null>({
      Method: 'DELETE',
      Url: `orders/${orderId}`,
      Token: token
    });
  }

  async placeOrder(dto:OrderHeaderCreateDTO, token: string): Promise<APIResponse<OrderHeaderGetDTO>> {
    return this.sendRequest<OrderHeaderGetDTO>({
      Method: 'POST',
      Url: `orders`,
      Data: dto,
      Token: token
    });
  }

  async updateOrder(dto:OrderHeaderUpdateDTO , token: string): Promise<APIResponse<null>> {
    return this.sendRequest<null>({
      Method: 'PUT',
      Url: `orders/${dto.Id}`,
      Data: dto,
      Token: token
    });
  }
}

export default OrderService;
