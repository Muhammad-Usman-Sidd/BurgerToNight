import axios from 'axios';
import BaseService from './BaseService';
import { APIResponse } from '../models/APIResult';
import { OrderCreateDTO, OrderGetDTO } from "../models/OrderDtos";

const API_URL = import.meta.env.VITE_API_URL;

export interface IOrderService {
  createOrder(dto: OrderCreateDTO, token: string): Promise<APIResponse<OrderGetDTO>>;
  getUserOrders(userId: string, token: string): Promise<APIResponse<OrderGetDTO[]>>;
  getOrderStatus(orderId: string, token: string): Promise<APIResponse<OrderGetDTO>>;
}

class OrderService extends BaseService implements IOrderService {
  constructor() {
    super(API_URL);
  }

  async createOrder(dto: OrderCreateDTO, token: string): Promise<APIResponse<OrderGetDTO>> {
    return this.sendRequest<OrderGetDTO>({
      Url: `/orders`,
      Method: 'POST',
      Data: dto,
      Token: token
    });
  }

  async getUserOrders(userId: string, token: string): Promise<APIResponse<OrderGetDTO[]>> {
    return this.sendRequest<OrderGetDTO[]>({
      Url: `/orders/user/${userId}`,
      Method: 'GET',
      Token: token
    });
  }

  async getOrderStatus(orderId: string, token: string): Promise<APIResponse<OrderGetDTO>> {
    return this.sendRequest<OrderGetDTO>({
      Url: `/orders/${orderId}/status`, 
      Method: 'GET',
      Token: token
    });
  }
}

export default OrderService;
