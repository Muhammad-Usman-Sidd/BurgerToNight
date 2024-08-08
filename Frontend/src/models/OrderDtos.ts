import { OrderDetailCreateDTO,OrderDetailGetDTO } from "./OrderDetailDtos";

export interface OrderGetDTO {
  Id: number;
  UserId: number;
  OrderDate: string;
  OrderTotal: number;
  OrderStatus: string;
  PaymentStatus: string;
  PaymentIntentId?: string;
  PaymentDate: string;
  PhoneNumber?: string;
  Address?: string;
  Name: string;
  Items: OrderDetailGetDTO[];
}

export interface OrderCreateDTO{
  UserId: number;
  OrderTotal: number;
  PhoneNumber?: string;
  Address?: string;
  Name: string;
  Items: OrderDetailCreateDTO[];
}

export interface OrderUpdateDTO{
  Id:number
  OrderStatus:string,
  PaymentStatus:string
}