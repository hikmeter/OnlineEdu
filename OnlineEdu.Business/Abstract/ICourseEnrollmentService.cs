using OnlineEdu.Dto.Dtos.CourseEnrollmentDtos;

namespace OnlineEdu.Business.Abstract
{
    public interface ICourseEnrollmentService
    {
        Task<List<ResultCourseEnrollmentDto>> GetCourseEnrollmentList();
        Task<List<GetCourseEnrollmentsWithCourseNamesDto>> GetCourseEnrollmentsWithCourseNames();
        Task<List<GetCourseEnrollmentsWithCourseNamesDto>> GetCourseEnrollmentsByStudentId(int id);
        Task<GetCourseEnrollmentByIdDto> GetCourseEnrollmentById(int id);
        Task CreateCourseEnrollment(CreateCourseEnrollmentDto dto);
        Task UpdateCourseEnrollment(UpdateCourseEnrollmentDto dto);
        Task DeleteCourseEnrollment(int id);
    }
}
