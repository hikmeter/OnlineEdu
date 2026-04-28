namespace OnlineEdu.Dto.Dtos.SubscriberDtos
{
    public class GetSubscriberByIdDto
    {
        public int SubscriberId { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
