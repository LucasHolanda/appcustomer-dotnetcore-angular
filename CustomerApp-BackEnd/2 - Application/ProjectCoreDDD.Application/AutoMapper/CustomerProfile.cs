using AutoMapper;
using ProjectCoreDDD.Application.Dtos;
using ProjectCoreDDD.Domain.Entities;

namespace ProjectCoreDDD.Application.AutoMapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
               .ReverseMap()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
               .ForMember(dest => dest.LastPurchase, opt => opt.MapFrom(src => src.LastPurchase))
               .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.GenderId))
               .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
               .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.RegionId))
               .ForMember(dest => dest.ClassificationId, opt => opt.MapFrom(src => src.ClassificationId))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<CustomerDto, FilterCustomerDto>()
               .ReverseMap()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.GenderId))
               .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
               .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.RegionId))
               .ForMember(dest => dest.ClassificationId, opt => opt.MapFrom(src => src.ClassificationId))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
        }
    }
}