namespace OnlineEdu.Presentation.Dtos.UserDtos
{
    public class LoginResultDto
    {
        public bool Succeeded { get; set; }
        public string? Role { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
