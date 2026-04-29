using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Repositories
{
    public class CourseCategoryRepository(AppDbContext _context) : ICourseCategoryRepository
    {
        public async Task<CourseCategory> ToggleShownStatus(int id)
        {
            var value = await _context.CourseCategories.FindAsync(id);
            value.IsShown = !value.IsShown;
            await _context.SaveChangesAsync();
            return value;
        }
    }
}
