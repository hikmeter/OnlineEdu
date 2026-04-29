namespace OnlineEdu.Presentation.Dtos.CourseCategoryDtos
{
    public class UpdateCourseCategoryDto
    {
        public int courseCategoryId { get; set; }
        public string categoryName { get; set; }
        public string icon { get; set; }
        public string description { get; set; }
        public bool isShown { get; set; }
    }
}
