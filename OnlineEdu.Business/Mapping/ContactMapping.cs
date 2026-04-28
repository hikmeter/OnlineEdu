using AutoMapper;
using OnlineEdu.Dto.Dtos.ContactDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();
            CreateMap<ResultContactDto, Contact>().ReverseMap();
            CreateMap<GetContactByIdDto, Contact>().ReverseMap();
        }
    }
}
