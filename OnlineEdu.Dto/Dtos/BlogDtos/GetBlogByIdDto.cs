using OnlineEdu.Dto.Dtos.BlogCategoryDtos;

namespace OnlineEdu.Dto.Dtos.BlogDtos
{
    public class GetBlogByIdDto
    {
        public int BlogId { get; set; }
        public int BlogCategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime BlogDate { get; set; }
        public ResultBlogCategoryDto BlogCategory { get; set; }
        public int WriterId { get; set; }
    }
}
