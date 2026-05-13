using Microsoft.AspNetCore.Identity;

namespace OnlineEdu.Entity.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? ImageUrl { get; set; }
        public List<Course> Courses { get; set; }
        public List<CourseEnrollment> CourseEnrollments { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
