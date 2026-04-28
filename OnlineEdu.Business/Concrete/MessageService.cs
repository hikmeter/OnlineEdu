using AutoMapper;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Dto.Dtos.MessageDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class MessageService(IRepository<Message> _repository, IMapper _mapper) : IMessageService
    {
        public async Task CreateMessage(CreateMessageDto dto)
        {
            var result = _mapper.Map<Message>(dto);
            await _repository.CreateAsync(result);
        }

        public async Task DeleteMessage(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<GetMessageByIdDto> GetMessageById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetMessageByIdDto>(value);
        }

        public async Task<List<ResultMessageDto>> GetMessageList()
        {
            var values = await _repository.GetListAsync();
            return _mapper.Map<List<ResultMessageDto>>(values);
        }

        public async Task UpdateMessage(UpdateMessageDto dto)
        {
            var value = _mapper.Map<Message>(dto);
            await _repository.UpdateAsync(value);
        }
    }
}
