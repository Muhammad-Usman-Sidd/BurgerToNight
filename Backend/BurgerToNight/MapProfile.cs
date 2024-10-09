using AutoMapper;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;

namespace BurgerToNightAPI
{
    public class MapProfile : Profile
    {

        public MapProfile()
        {
            CreateMap<Category, CategoryPostDTO>().ReverseMap();
            CreateMap<Category, CategoryGetDTO>();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();

            CreateMap<Product, ProductPostDTO>().ReverseMap();
            CreateMap<Product, ProductGetDTO>();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();

            CreateMap<OrderCreateDTO, OrderGetDTO>();
            CreateMap<OrderCreateDTO, OrderHeader>();
            CreateMap<OrderHeader, OrderGetDTO>();

            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}
