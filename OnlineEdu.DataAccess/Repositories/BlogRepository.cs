using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Repositories
{
    public class BlogRepository(AppDbContext _context) : IBlogRepository
    {
        public async Task<List<Blog>> GetAllBlogsWithCategories()
        {
            var values = await _context.Blogs.Include(x => x.BlogCategory).ToListAsync();
            return values;
        }
    }
}
