namespace OnlineEdu.Presentation.Dtos.BlogDtos
{
    public class CreateBlogDto
    {
        public int blogCategoryId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string imageUrl { get; set; }
    }
}
