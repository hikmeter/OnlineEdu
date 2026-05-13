using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetCoursesWithCategoriesAsync();
        Task<Course> ToggleShownStatus(int id);
        Task<List<Course>> Get3ActivePopularCoursesAsync();
        Task<List<Course>> GetCoursesByTeacherIdAsync(int id);
    }
}
