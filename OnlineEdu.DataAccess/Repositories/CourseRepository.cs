using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Repositories
{
    public class CourseRepository(AppDbContext _context) : ICourseRepository
    {
        public async Task<List<Course>> GetCoursesWithCategoriesAsync()
        {
            var values = await _context.Courses.Include(x => x.CourseCategory).ToListAsync();
            return values;
        }

        public async Task<Course> ToggleShownStatus(int id)
        {
            var value = await _context.Courses.FindAsync(id);
            value.IsShown = !value.IsShown;
            await _context.SaveChangesAsync();
            return value;
        }
    }
}

