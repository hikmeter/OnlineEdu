using OnlineEdu.Dto.Dtos.CourseDtos;

namespace OnlineEdu.Dto.Dtos.CourseEnrollmentDtos
{
    public class GetCourseEnrollmentsWithCourseNamesDto
    {
        public int CourseEnrollmentId { get; set; }
        public int AppUserId { get; set; }
        public GetCoursesWithCategoriesDto Course { get; set; }
    }
}
