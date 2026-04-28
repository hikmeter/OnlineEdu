using OnlineEdu.Dto.Dtos.CourseDtos;

namespace OnlineEdu.Dto.Dtos.CourseCategoryDtos
{
    public class GetCourseCategoryByIdDto
    {
        public int CourseCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool IsShown { get; set; }
        public List<ResultCourseDto> Courses { get; set; }
    }
}
