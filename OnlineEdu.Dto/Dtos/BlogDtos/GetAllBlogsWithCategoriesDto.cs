namespace OnlineEdu.Dto.Dtos.BlogDtos
{
    public class GetAllBlogsWithCategoriesDto
    {
        public int BlogId { get; set; }
        public int BlogCategoryId { get; set; }
        public string BlogCategoryName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime BlogDate { get; set; }
        public int WriterId { get; set; }
        public string WriterName { get; set; }
    }
}
