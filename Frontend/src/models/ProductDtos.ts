export interface ProductCreateDTO {
  Name: string;
  Description: string;
  Price: number;
  PreparingTime: string;
  BCategoryId: number | null;
  BurgerCategory: string,
  Image: string;
}

export interface ProductUpdateDTO {
  Id: number;
  Name: string;
  Description: string;
  Price: number;
  PreparingTime: string;
  BCategoryId: number | null;
  Image: string;
}

export interface ProductGetDTO {
  Id: number;
  Name: string;
  Description: string;
  Price: number;
  PreparingTime: string;
  BCategoryId: number;
  BurgerCategory:string;
  Image: string;
}