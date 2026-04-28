using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.TestimonialDtos;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(ITestimonialService _testimonialService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _testimonialService.GetTestimonialList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _testimonialService.GetTestimonialById(id);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _testimonialService.DeleteTestimonial(id);
            return Ok("Referans Başarıyla Silindi!");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialDto dto)
        {
            await _testimonialService.CreateTestimonial(dto);
            return Ok("Referans Başarıyla Eklendi!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTestimonialDto dto)
        {
            await _testimonialService.UpdateTestimonial(dto);
            return Ok("Referans Başarıyla Güncellendi!");
        }
    }
}
