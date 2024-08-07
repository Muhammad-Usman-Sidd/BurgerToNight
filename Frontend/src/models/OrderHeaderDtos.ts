import { OrderDetailCreateDTO,OrderDetailGetDTO } from "./OrderDetailDtos";

export interface OrderHeaderGetDTO {
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
  City?: string;
  Name: string;
  Items: OrderDetailGetDTO[];
}

export interface OrderHeaderCreateDTO{
  UserId: number;
  OrderTotal: number;
  PhoneNumber: string;
  Address?: string;
  City?: string;
  Name: string;
  Items: OrderDetailCreateDTO[];
}

export interface OrderHeaderUpdateDTO{
  Id:number
  OrderStatus:string,
  PaymentStatus:string
}