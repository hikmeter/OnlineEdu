using OnlineEdu.Dto.Dtos.CourseDtos;

namespace OnlineEdu.Business.Abstract
{
    public interface ICourseService
    {
        Task<List<ResultCourseDto>> GetCourseList();
        Task<GetCourseByIdDto> GetCourseById(int id);
        Task CreateCourse(CreateCourseDto dto);
        Task UpdateCourse(UpdateCourseDto dto);
        Task DeleteCourse(int id);
    }
}
