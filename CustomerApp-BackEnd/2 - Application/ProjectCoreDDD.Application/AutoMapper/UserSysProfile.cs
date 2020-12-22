using AutoMapper;
using ProjectCoreDDD.Application.Dtos;
using ProjectCoreDDD.Domain.Entities;

namespace ProjectCoreDDD.Application.AutoMapper
{
    public class UserSysProfile : Profile
    {
        public UserSysProfile()
        {
            CreateMap<UserSys, UserSysDto>()
               .ReverseMap()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.Password, opt => opt.Ignore())
               .ForSourceMember(dest => dest.Password, opt => opt.DoNotValidate())
               .ForMember(dest => dest.UserRoleId, opt => opt.MapFrom(src => src.UserRoleId));
        }
    }
}
