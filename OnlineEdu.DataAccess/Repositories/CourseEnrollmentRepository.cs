using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Repositories
{
    public class CourseEnrollmentRepository(AppDbContext _context) : ICourseEnrollmentRepository
    {
        public async Task<List<CourseEnrollment>> GetAllCourseEnrollmentsWithCourseNamesAsync()
        {
            return await _context.CourseEnrollments.Include(x => x.Course).ThenInclude(y => y.CourseCategory).ToListAsync();
        }

        public async Task<List<CourseEnrollment>> GetCourseEnrollmentsByStudentIdAsync(int id)
        {
            return await _context.CourseEnrollments.Include(x => x.Course).ThenInclude(z => z.CourseCategory).Where(y => y.AppUserId == id).ToListAsync();
        }
    }
}
