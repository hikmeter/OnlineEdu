namespace OnlineEdu.Presentation.Dtos.CourseDtos
{
    public class CreateCourseDto
    {
        public string courseName { get; set; }
        public string imageUrl { get; set; }
        public int courseCategoryId { get; set; }
        public decimal price { get; set; }
        public bool isShown { get; set; }
        public int AppUserId { get; set; }
    }
}
