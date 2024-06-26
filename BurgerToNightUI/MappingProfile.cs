using AutoMapper;
using BurgerToNightUI.Models.DTO;

namespace BurgerToNightUI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BCategoryDTO, BCategoryEditDTO>().ReverseMap();
            CreateMap<BCategoryCreateDTO, BCategoryDTO>().ReverseMap();


            CreateMap<BProductCreateDTO, BProductDTO>().ReverseMap();
            CreateMap<BProductEditDTO, BProductDTO>().ReverseMap();
            CreateMap<BProductDeleteDTO, BProductDTO>().ReverseMap();
        }
    }
}
