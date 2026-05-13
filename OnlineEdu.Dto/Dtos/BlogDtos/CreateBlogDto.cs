namespace OnlineEdu.Dto.Dtos.BlogDtos
{
    public class CreateBlogDto
    {
        public int BlogCategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int WriterId { get; set; }
    }
}
