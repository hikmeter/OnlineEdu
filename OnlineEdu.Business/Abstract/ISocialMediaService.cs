using OnlineEdu.Dto.Dtos.SocialMediaDtos;

namespace OnlineEdu.Business.Abstract
{
    public interface ISocialMediaService
    {
        Task<List<ResultSocialMediaDto>> GetSocialMediaList();
        Task<GetSocialMediaByIdDto> GetSocialMediaById(int id);
        Task CreateSocialMedia(CreateSocialMediaDto dto);
        Task UpdateSocialMedia(UpdateSocialMediaDto dto);
        Task DeleteSocialMedia(int id);
    }
}
