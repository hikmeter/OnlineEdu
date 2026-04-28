using OnlineEdu.Dto.Dtos.ContactDtos;

namespace OnlineEdu.Business.Abstract
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetContactList();
        Task<GetContactByIdDto> GetContactById(int id);
        Task CreateContact(CreateContactDto dto);
        Task UpdateContact(UpdateContactDto dto);
        Task DeleteContact(int id);
    }
}
