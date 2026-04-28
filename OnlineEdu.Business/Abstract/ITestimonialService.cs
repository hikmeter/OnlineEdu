using OnlineEdu.Dto.Dtos.TestimonialDtos;

namespace OnlineEdu.Business.Abstract
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetTestimonialList();
        Task<GetTestimonialByIdDto> GetTestimonialById(int id);
        Task CreateTestimonial(CreateTestimonialDto dto);
        Task UpdateTestimonial(UpdateTestimonialDto dto);
        Task DeleteTestimonial(int id);
    }
}
