using AutoMapper;
using OnlineEdu.Dto.Dtos.TestimonialDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Mapping
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping()
        {
            CreateMap<CreateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<GetTestimonialByIdDto, Testimonial>().ReverseMap();
        }
    }
}
