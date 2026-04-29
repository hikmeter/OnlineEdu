namespace OnlineEdu.Presentation.Dtos.BlogDtos
{
    public class UpdateBlogDto
    {
        public int blogId { get; set; }
        public int blogCategoryId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string imageUrl { get; set; }
        public DateTime blogDate { get; set; }
    }
}
