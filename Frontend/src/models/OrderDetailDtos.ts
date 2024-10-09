import { ProductGetDTO } from "./ProductDtos";

export interface OrderDetailGetDTO {
  Id: number;
  product: ProductGetDTO;
  Quantity: number;
}
export interface OrderDetailCreateDTO {
  ProductId: number;
  Quantity: number;
  Price: number;
}
