using OnlineEdu.Dto.Dtos.BlogDtos;

namespace OnlineEdu.Business.Abstract
{
    public interface IBlogService
    {
        Task<List<ResultBlogDto>> GetBlogList();
        Task<List<GetAllBlogsWithCategoriesDto>> GetAllBlogsWithCategories();
        Task<GetBlogByIdDto> GetBlogById(int id);
        Task CreateBlog(CreateBlogDto dto);
        Task UpdateBlog(UpdateBlogDto dto);
        Task DeleteBlog(int id);
    }
}
