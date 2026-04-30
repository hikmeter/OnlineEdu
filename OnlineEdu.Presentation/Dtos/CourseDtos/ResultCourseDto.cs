namespace OnlineEdu.Presentation.Dtos.CourseDtos
{
    public class ResultCourseDto
    {
        public int courseId { get; set; }
        public string courseName { get; set; }
        public string imageUrl { get; set; }
        public int courseCategoryId { get; set; }
        public string courseCategoryName { get; set; }
        public decimal price { get; set; }
        public bool isShown { get; set; }
    }
}
