using AutoMapper;
using OnlineEdu.Dto.Dtos.TeacherSocialDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Mapping
{
    public class TeacherSocialMapping : Profile
    {
        public TeacherSocialMapping()
        {
            {
                CreateMap<CreateTeacherSocialDto, TeacherSocial>().ReverseMap();
                CreateMap<UpdateTeacherSocialDto, TeacherSocial>().ReverseMap();
                CreateMap<ResultTeacherSocialDto, TeacherSocial>().ReverseMap();
                CreateMap<GetTeacherSocialByIdDto, TeacherSocial>().ReverseMap();
                CreateMap<TeacherSocial, GetTeacherSocialsWithSocialMediasDto>().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.SocialMedia.Title)).ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.SocialMedia.Icon));
            }
        }
    }
}
