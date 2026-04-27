using AutoMapper;
using OnlineEdu.Dto.Dtos.BannerDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Mapping
{
    public class BannerMapping : Profile
    {
        public BannerMapping()
        {
            CreateMap<CreateBannerDto, Banner>().ReverseMap();
            CreateMap<UpdateBannerDto, Banner>().ReverseMap();
            CreateMap<ResultBannerDto, Banner>().ReverseMap();
            CreateMap<GetBannerByIdDto, Banner>().ReverseMap();
        }
    }
}
