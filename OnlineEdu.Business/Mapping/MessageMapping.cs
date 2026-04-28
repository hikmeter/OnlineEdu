using AutoMapper;
using OnlineEdu.Dto.Dtos.MessageDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<CreateMessageDto, Message>().ReverseMap();
            CreateMap<UpdateMessageDto, Message>().ReverseMap();
            CreateMap<ResultMessageDto, Message>().ReverseMap();
            CreateMap<GetMessageByIdDto, Message>().ReverseMap();
        }
    }
}
