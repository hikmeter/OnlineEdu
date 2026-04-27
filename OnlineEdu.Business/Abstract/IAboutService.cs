using OnlineEdu.Dto.Dtos.AboutDtos;

namespace OnlineEdu.Business.Abstract
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAboutList();
        Task<GetAboutByIdDto> GetAboutById(int id);
        Task CreateAbout(CreateAboutDto dto);
        Task UpdateAbout(UpdateAboutDto dto);
        Task DeleteAbout(int id);
    }
}
