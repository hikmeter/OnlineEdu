using AutoMapper;
using OnlineEdu.Dto.Dtos.SocialMediaDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Mapping
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<CreateSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<ResultSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<GetSocialMediaByIdDto, SocialMedia>().ReverseMap();
        }
    }
}
