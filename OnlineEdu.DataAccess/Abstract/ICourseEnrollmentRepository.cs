using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ICourseEnrollmentRepository
    {
        Task<List<CourseEnrollment>> GetAllCourseEnrollmentsWithCourseNamesAsync();
        Task<List<CourseEnrollment>> GetCourseEnrollmentsByStudentIdAsync(int id);
    }
}
