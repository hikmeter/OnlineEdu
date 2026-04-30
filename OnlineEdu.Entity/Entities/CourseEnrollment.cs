namespace OnlineEdu.Entity.Entities
{
    public class CourseEnrollment
    {
        public int CourseEnrollmentId { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
