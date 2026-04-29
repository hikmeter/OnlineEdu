using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ICourseCategoryRepository
    {
        Task<CourseCategory> ToggleShownStatus(int id);
    }
}
