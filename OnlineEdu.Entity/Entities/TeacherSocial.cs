namespace OnlineEdu.Entity.Entities
{
    public class TeacherSocial
    {
        public int TeacherSocialId { get; set; }
        public int SocialMediaId { get; set; }
        public SocialMedia SocialMedia { get; set; }
        public string Url { get; set; }
        public int TeacherId { get; set; }
        public AppUser Teacher { get; set; }
    }
}
