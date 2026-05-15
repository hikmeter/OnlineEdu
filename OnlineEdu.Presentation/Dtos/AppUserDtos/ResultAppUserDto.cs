using OnlineEdu.Presentation.Dtos.TeacherSocialDtos;

namespace OnlineEdu.Presentation.Dtos.AppUserDtos
{
    public class ResultAppUserDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string imageUrl { get; set; }
        public List<ResultTeacherSocialDto> teacherSocials { get; set; }
    }
}
