using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogsWithCategories();
    }
}
