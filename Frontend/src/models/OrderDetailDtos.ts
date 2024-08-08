export interface OrderDetailGetDTO {
  Id: number;
  ProductId: number;
  Quantity: number;
  Price: number;
}
export interface OrderDetailCreateDTO {
    ProductId: number;
    Quantity: number;
    Price: number;
}