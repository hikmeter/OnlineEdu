using AutoMapper;
using OnlineEdu.Dto.Dtos.SubscriberDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Mapping
{
    public class SubscriberMapping : Profile
    {
        public SubscriberMapping()
        {
            CreateMap<CreateSubscriberDto, Subscriber>().ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => false));
            CreateMap<UpdateSubscriberDto, Subscriber>().ReverseMap();
            CreateMap<ResultSubscriberDto, Subscriber>().ReverseMap();
            CreateMap<GetSubscriberByIdDto, Subscriber>().ReverseMap();
        }
    }
}
