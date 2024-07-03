using AutoMapper;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using Microsoft.Azure.Cosmos;

namespace BurgerToNightAPI
{
    public class MapProfile : Profile
    {

        public MapProfile()
        {
            CreateMap<BurgerCategory, BCategoryPostDTO>().ReverseMap();
            CreateMap<BurgerCategory, BCategoryGetDTO>();
            CreateMap<BurgerCategory,BCategoryUpdateDTO>().ReverseMap();

            CreateMap<BurgerProduct, BProductPostDTO>().ReverseMap();
            CreateMap<BurgerProduct, BProductGetDTO>();
            CreateMap<BurgerProduct, BProductUpdateDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}
