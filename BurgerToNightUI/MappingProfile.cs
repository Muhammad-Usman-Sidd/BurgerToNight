﻿using AutoMapper;
using BurgerToNightUI.Models.DTO;

namespace BurgerToNightUI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BCategoryDTO, BCategoryUpdateDTO>().ReverseMap();
            CreateMap<BCategoryCreateDTO, BCategoryDTO>().ReverseMap();


            CreateMap<BProductCreateDTO, BProductDTO>().ReverseMap();
            CreateMap<BProductUpdateDTO, BProductDTO>().ReverseMap();
            CreateMap<BProductDeleteDTO, BProductDTO>().ReverseMap();
        }
    }
}
