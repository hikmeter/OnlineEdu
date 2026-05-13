namespace OnlineEdu.Dto.Dtos.TeacherSocialDtos
{
    public class GetTeacherSocialsWithSocialMediasDto
    {
        public int TeacherSocialId { get; set; }
        public int SocialMediaId { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int TeacherId { get; set; }
    }
}
