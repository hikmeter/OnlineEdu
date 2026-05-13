using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogsWithCategoriesAndWritersAsync();
        Task<List<Blog>> GetBlogsByWriterIdAsync(int id);
    }
}
