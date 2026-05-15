using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface IAppUserRepository
    {
        Task<List<AppUser>> GetUsersWithSocials();
    }
}
