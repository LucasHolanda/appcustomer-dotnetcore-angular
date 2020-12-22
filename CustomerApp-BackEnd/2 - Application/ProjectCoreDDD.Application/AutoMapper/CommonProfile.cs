using AutoMapper;
using ProjectCoreDDD.Application.Dtos;
using ProjectCoreDDD.Domain.Entities;

namespace ProjectCoreDDD.Application.AutoMapper
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CityMap();
            ClassificationMap();
            GenderMap();
            RegionMap();
        }

        private void CityMap()
        {
            CreateMap<City, CityDto>()
               .ReverseMap()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.RegionId))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }

        private void ClassificationMap()
        {
            CreateMap<Classification, ClassificationDto>()
               .ReverseMap()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
        private void GenderMap()
        {
            CreateMap<Gender, GenderDto>()
               .ReverseMap()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }

        private void RegionMap()
        {
            CreateMap<Region, RegionDto>()
               .ReverseMap()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}