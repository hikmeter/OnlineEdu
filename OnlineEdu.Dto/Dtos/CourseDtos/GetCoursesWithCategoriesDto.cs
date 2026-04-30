namespace OnlineEdu.Dto.Dtos.CourseDtos
{
    public class GetCoursesWithCategoriesDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string ImageUrl { get; set; }
        public int CourseCategoryId { get; set; }
        public string CourseCategoryName { get; set; }
        public decimal Price { get; set; }
        public bool IsShown { get; set; }
    }
}
