using AutoMapper;
using OnlineEdu.Dto.Dtos.AppUserDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Mapping
{
    public class AppUserMapping : Profile
    {
        public AppUserMapping()
        {
            CreateMap<AppUser, ResultAppUserDto>();
        }
    }
}
