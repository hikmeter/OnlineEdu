using OnlineEdu.Dto.Dtos.BlogCategoryDtos;

namespace OnlineEdu.Business.Abstract
{
    public interface IBlogCategoryService
    {
        Task<List<ResultBlogCategoryDto>> GetBlogCategoryList();
        Task<GetBlogCategoryByIdDto> GetBlogCategoryById(int id);
        Task CreateBlogCategory(CreateBlogCategoryDto dto);
        Task UpdateBlogCategory(UpdateBlogCategoryDto dto);
        Task DeleteBlogCategory(int id);
    }
}
