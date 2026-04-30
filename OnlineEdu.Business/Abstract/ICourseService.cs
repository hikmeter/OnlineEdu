using OnlineEdu.Dto.Dtos.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface ICourseService
    {
        Task<List<ResultCourseDto>> GetCourseList();
        Task<List<GetCoursesWithCategoriesDto>> GetCoursesWithCategories();
        Task<GetCourseByIdDto> GetCourseById(int id);
        Task<Course> ToggleShownStatus(int id);
        Task CreateCourse(CreateCourseDto dto);
        Task UpdateCourse(UpdateCourseDto dto);
        Task DeleteCourse(int id);
    }
}
