export interface CategoryGetDTO{
    Id:number,
    Name:string,
    Description:string,
    Icon:string
}
export interface CategoryCreateDTO{
    Name:string,
    Description:string,
    Icon:string
}
export interface CategoryUpdateDTO{
    Id:number
    Name?:string,
    Description?:string,
    Icon?:string
}

