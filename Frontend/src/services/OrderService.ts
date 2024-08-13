import BaseService from './BaseService';
import { APIResponse } from '../models/APIResult';
import { OrderGetDTO,OrderCreateDTO,OrderUpdateDTO } from '../models/OrderDtos';

export interface IOrderService {
  getUserOrders(userId: string, token: string): Promise<APIResponse<OrderGetDTO[]>>;
  deleteOrder(orderId: number, token: string): Promise<APIResponse<null>>;
  placeOrder(dto:OrderCreateDTO ,token: string): Promise<APIResponse<OrderGetDTO>>;
  updateOrder(dto:OrderUpdateDTO, token: string): Promise<APIResponse<null>>;
}

class OrderService extends BaseService implements IOrderService {
    constructor() {
      super(import.meta.env.VITE_API_URL);
    }

  async getUserOrders(userId: string): Promise<APIResponse<OrderGetDTO[]>> {
    return this.sendRequest<OrderGetDTO[]>({
      Method: 'GET',
      Url: `orders/${userId}`,
    });
  }
  
  async getAllOrders(): Promise<APIResponse<OrderGetDTO[]>> {
    return this.sendRequest<OrderGetDTO[]>({
      Method: 'GET',
      Url: `orders`,
    });
  }

  async deleteOrder(id: number): Promise<APIResponse<null>> {
    return this.sendRequest<null>({
      Method: 'DELETE',
      Url: `orders/${id}`,
    });
  }

  async placeOrder(dto:OrderCreateDTO): Promise<APIResponse<OrderGetDTO>> {
    return this.sendRequest<OrderGetDTO>({
      Method: 'POST',
      Url: `orders`,
      Data: dto,
    });
  }

  async updateOrder(dto:OrderUpdateDTO): Promise<APIResponse<null>> {
    return this.sendRequest<null>({
      Method: 'PUT',
      Url: `orders/${dto.Id}`,
      Data: dto,
    });
  }
}

export default OrderService;
