using AutoMapper;
using moduloRh.Domain.Dto;
using moduloRh.Domain.Model;

namespace moduloRh.AutoMapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
        }
    }
}