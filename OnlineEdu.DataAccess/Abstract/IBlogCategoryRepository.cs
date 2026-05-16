using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface IBlogCategoryRepository
    {
        Task<List<BlogCategory>> GetBlogCategoriesWithBlogCountAsync();
    }
}
