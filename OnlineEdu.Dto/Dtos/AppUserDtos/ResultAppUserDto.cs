using OnlineEdu.Dto.Dtos.TeacherSocialDtos;

namespace OnlineEdu.Dto.Dtos.AppUserDtos
{
    public class ResultAppUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public List<ResultTeacherSocialDto> TeacherSocials { get; set; }
    }
}
