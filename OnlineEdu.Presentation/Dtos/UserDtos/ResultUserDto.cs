using OnlineEdu.Presentation.Dtos.TeacherSocialDtos;

namespace OnlineEdu.Presentation.Dtos.UserDtos
{
    public class ResultUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public List<ResultTeacherSocialDto> TeacherSocials { get; set; } = new();
    }
}
