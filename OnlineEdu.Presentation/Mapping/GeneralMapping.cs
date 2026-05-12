using AutoMapper;
using OnlineEdu.Entity.Entities;
using OnlineEdu.Presentation.Dtos.RoleDtos;

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
        }
    }
}
