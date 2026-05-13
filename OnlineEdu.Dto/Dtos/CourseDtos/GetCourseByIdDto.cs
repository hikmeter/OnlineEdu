using OnlineEdu.Dto.Dtos.CourseCategoryDtos;

namespace OnlineEdu.Dto.Dtos.CourseDtos
{
    public class GetCourseByIdDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string ImageUrl { get; set; }
        public int CourseCategoryId { get; set; }
        public ResultCourseCategoryDto Category { get; set; }
        public decimal Price { get; set; }
        public bool IsShown { get; set; }
        public int AppUserId { get; set; }
    }
}
