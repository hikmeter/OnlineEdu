using OnlineEdu.Presentation.Dtos.CourseDtos;

namespace OnlineEdu.Presentation.Dtos.CourseEnrollmentDtos
{
    public class ResultCourseEnrollmentDto
    {
        public int courseEnrollmentId { get; set; }
        public int appUserId { get; set; }
        public ResultCourseDto course { get; set; }
    }
}
