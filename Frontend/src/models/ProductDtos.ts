export interface ProductCreateUpdateDTO {
  Id?: number;
  Name: string;
  Description: string;
  Price: number;
  PreparingTime: string;
  CategoryId: number | undefined;
  Image: string;
}

export interface ProductGetDTO {
  Id: number;
  Name: string;
  Description: string;
  Price: number;
  PreparingTime: string;
  CategoryId: number;
  productCategory: string;
  Image: string;
  TotalSales: number;
}
