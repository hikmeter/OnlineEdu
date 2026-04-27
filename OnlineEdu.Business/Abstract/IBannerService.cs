using OnlineEdu.Dto.Dtos.BannerDtos;

namespace OnlineEdu.Business.Abstract
{
    public interface IBannerService
    {
        Task<List<ResultBannerDto>> GetBannerList();
        Task<GetBannerByIdDto> GetBannerById(int id);
        Task CreateBanner(CreateBannerDto dto);
        Task UpdateBanner(UpdateBannerDto dto);
        Task DeleteBanner(int id);
    }
}
