using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogsWithCategoriesAndWritersAsync();
        Task<List<Blog>> GetLast4BlogsWithCategoriesAndWritersAsync();
        Task<List<Blog>> GetBlogsByWriterIdAsync(int id);
    }
}
