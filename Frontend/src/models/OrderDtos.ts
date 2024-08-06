export interface OrderCreateDTO {
    UserId: number;
    Items: {
      ProductId: number;
      Quantity: number;
      Price: number;
    }[];
  }
  
  export interface OrderGetDTO {
    Id: number;
    Items: {
      ProductId: number;
      Quantity: number;
      Price: number;
    }[];
    OrderDate: string;
    Status: OrderStatus;
  }
  
  export enum OrderStatus {
    Preparing = 'Preparing',
    OnTheWay = 'On The Way',
    Delivered = 'Delivered',
  }
  