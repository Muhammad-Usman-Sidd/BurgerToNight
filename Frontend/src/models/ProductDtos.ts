export interface ProductCreateDTO {
  Name: string;
  Description: string;
  Price: number;
  PreparingTime: string;
  CategoryId: number | null;
  productCategory: string,
  Image: string;
}

export interface ProductUpdateDTO {
  Id: number;
  Name: string;
  Description: string;
  Price: number;
  PreparingTime: string;
  CategoryId: number | null;
  Image: string;
}

export interface ProductGetDTO {
  Id: number;
  Name: string;
  Description: string;
  Price: number;
  PreparingTime: string;
  CategoryId: number;
  productCategory:string;
  Image: string;
}