using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Repositories
{
    public class BlogRepository(AppDbContext _context) : IBlogRepository
    {
        public async Task<List<Blog>> GetAllBlogsWithCategoriesAndWritersAsync()
        {
            var values = await _context.Blogs.Include(x => x.BlogCategory).Include(y => y.Writer).ToListAsync();
            return values;
        }

        public async Task<List<Blog>> GetBlogsByWriterIdAsync(int id)
        {
            return await _context.Blogs.Include(x => x.BlogCategory).Include(y => y.Writer).Where(z => z.WriterId == id).ToListAsync();
        }

        public async Task<List<Blog>> GetLast4BlogsWithCategoriesAndWritersAsync()
        {
            return await _context.Blogs.Include(x => x.BlogCategory).Include(y => y.Writer).OrderByDescending(z => z.BlogDate).ToListAsync();
        }
    }
}
