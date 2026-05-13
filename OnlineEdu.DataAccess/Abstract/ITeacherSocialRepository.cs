using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ITeacherSocialRepository
    {
        Task<List<TeacherSocial>> GetTeacherSocialsByIdAsync(int id);
    }
}
