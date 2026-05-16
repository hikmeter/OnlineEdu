using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Repositories
{
    public class BlogCategoryRepository(AppDbContext _context) : IBlogCategoryRepository
    {
        public async Task<List<BlogCategory>> GetBlogCategoriesWithBlogCountAsync()
        {
            return await _context.BlogCategories.Include(x => x.Blogs).ToListAsync();
        }
    }
}
