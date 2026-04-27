using OnlineEdu.Dto.Dtos.BlogDtos;

namespace OnlineEdu.Dto.Dtos.BlogCategoryDtos
{
    public class UpdateBlogCategoryDto
    {
        public int BlogCategoryId { get; set; }
        public string Name { get; set; }
        public List<ResultBlogDto> Blogs { get; set; }
    }
}
