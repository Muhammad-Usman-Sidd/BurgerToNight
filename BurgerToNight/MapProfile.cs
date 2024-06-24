using AutoMapper;
using BurgerToNight.Models;
using BurgerToNight.Models.DTOs;

namespace BurgerToNight
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
        }
    }
}
