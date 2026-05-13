namespace OnlineEdu.Dto.Dtos.TeacherSocialDtos
{
    public class GetTeacherSocialByIdDto
    {
        public int TeacherSocialId { get; set; }
        public int SocialMediaId { get; set; }
        public string Url { get; set; }
        public int TeacherId { get; set; }
    }
}
