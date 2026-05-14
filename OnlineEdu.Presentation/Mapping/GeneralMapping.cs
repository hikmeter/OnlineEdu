using AutoMapper;
using OnlineEdu.Entity.Entities;
using OnlineEdu.Presentation.Dtos.RoleDtos;
using OnlineEdu.Presentation.Dtos.TeacherSocialDtos;
using OnlineEdu.Presentation.Dtos.UserDtos;

namespace OnlineEdu.Presentation.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<AppRole, ResultRoleDto>().ReverseMap();
            CreateMap<AppRole, CreateRoleDto>().ReverseMap();
            CreateMap<AppRole, UpdateRoleDto>().ReverseMap();
            CreateMap<AppRole, GetRoleByIdDto>().ReverseMap();
            CreateMap<AppUser, ResultUserDto>().ReverseMap();
            CreateMap<TeacherSocial, ResultTeacherSocialDto>().ReverseMap();
        }
    }
}
