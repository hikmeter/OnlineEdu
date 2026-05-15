using OnlineEdu.Dto.Dtos.AppUserDtos;

namespace OnlineEdu.Business.Abstract
{
    public interface IAppUserService
    {
        Task<List<ResultAppUserDto>> GetAllTeachers();
    }
}
