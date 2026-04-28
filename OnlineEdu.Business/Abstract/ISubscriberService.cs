using OnlineEdu.Dto.Dtos.SubscriberDtos;

namespace OnlineEdu.Business.Abstract
{
    public interface ISubscriberService
    {
        Task<List<ResultSubscriberDto>> GetSubscriberList();
        Task<GetSubscriberByIdDto> GetSubscriberById(int id);
        Task CreateSubscriber(CreateSubscriberDto dto);
        Task UpdateSubscriber(UpdateSubscriberDto dto);
        Task DeleteSubscriber(int id);
    }
}
