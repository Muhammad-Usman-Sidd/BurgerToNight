import { OrderDetailCreateDTO,OrderDetailGetDTO } from "./OrderDetailDtos";

export interface OrderGetDTO {
  Id: number;
  UserId: string;
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
  UserId: string;
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