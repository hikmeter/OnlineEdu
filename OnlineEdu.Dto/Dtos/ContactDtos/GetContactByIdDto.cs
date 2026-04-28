namespace OnlineEdu.Dto.Dtos.ContactDtos
{
    public class GetContactByIdDto
    {
        public int ContactId { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
