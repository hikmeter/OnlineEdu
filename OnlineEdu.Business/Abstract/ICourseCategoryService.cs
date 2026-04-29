using OnlineEdu.Dto.Dtos.CourseCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface ICourseCategoryService
    {
        Task<List<ResultCourseCategoryDto>> GetCourseCategoryList();
        Task<GetCourseCategoryByIdDto> GetCourseCategoryById(int id);
        Task<CourseCategory> ToggleShownStatus(int id);
        Task CreateCourseCategory(CreateCourseCategoryDto dto);
        Task UpdateCourseCategory(UpdateCourseCategoryDto dto);
        Task DeleteCourseCategory(int id);
    }
}
