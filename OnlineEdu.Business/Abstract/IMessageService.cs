using OnlineEdu.Dto.Dtos.MessageDtos;

namespace OnlineEdu.Business.Abstract
{
    public interface IMessageService
    {
        Task<List<ResultMessageDto>> GetMessageList();
        Task<GetMessageByIdDto> GetMessageById(int id);
        Task CreateMessage(CreateMessageDto dto);
        Task UpdateMessage(UpdateMessageDto dto);
        Task DeleteMessage(int id);
    }
}
