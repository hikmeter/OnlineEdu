using AutoMapper;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Dto.Dtos.ContactDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class ContactService(IRepository<Contact> _repository, IMapper _mapper) : IContactService
    {
        public async Task CreateContact(CreateContactDto dto)
        {
            var result = _mapper.Map<Contact>(dto);
            await _repository.CreateAsync(result);
        }

        public async Task DeleteContact(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<GetContactByIdDto> GetContactById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetContactByIdDto>(value);
        }

        public async Task<List<ResultContactDto>> GetContactList()
        {
            var values = await _repository.GetListAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task UpdateContact(UpdateContactDto dto)
        {
            var value = _mapper.Map<Contact>(dto);
            await _repository.UpdateAsync(value);
        }
    }
}
