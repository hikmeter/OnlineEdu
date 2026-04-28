using AutoMapper;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Dto.Dtos.TestimonialDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class TestimonialService(IRepository<Testimonial> _repository, IMapper _mapper) : ITestimonialService
    {
        public async Task CreateTestimonial(CreateTestimonialDto dto)
        {
            var result = _mapper.Map<Testimonial>(dto);
            await _repository.CreateAsync(result);
        }

        public async Task DeleteTestimonial(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<GetTestimonialByIdDto> GetTestimonialById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetTestimonialByIdDto>(value);
        }

        public async Task<List<ResultTestimonialDto>> GetTestimonialList()
        {
            var values = await _repository.GetListAsync();
            return _mapper.Map<List<ResultTestimonialDto>>(values);
        }

        public async Task UpdateTestimonial(UpdateTestimonialDto dto)
        {
            var value = _mapper.Map<Testimonial>(dto);
            await _repository.UpdateAsync(value);
        }
    }
}
