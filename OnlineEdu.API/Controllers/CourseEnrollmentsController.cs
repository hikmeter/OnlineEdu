using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.CourseEnrollmentDtos;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseEnrollmentsController(ICourseEnrollmentService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _service.GetCourseEnrollmentList();
            return Ok(values);
        }

        [HttpGet("WithCourseNames")]
        public async Task<IActionResult> GetCourseEnrollmentsWithCourseNames()
        {
            var values = await _service.GetCourseEnrollmentsWithCourseNames();
            return Ok(values);
        }

        [HttpGet("WithCourseNames/{id}")]
        public async Task<IActionResult> GetCourseEnrollmentsByStudentId(int id)
        {
            var values = await _service.GetCourseEnrollmentsByStudentId(id);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _service.GetCourseEnrollmentById(id);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteCourseEnrollment(id);
            return Ok("Kurs Kaydı Başarıyla Silindi!");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseEnrollmentDto dto)
        {
            await _service.CreateCourseEnrollment(dto);
            return Ok("Kurs Kaydı Başarıyla Oluşturuldu!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCourseEnrollmentDto dto)
        {
            await _service.UpdateCourseEnrollment(dto);
            return Ok("Kurs Kaydı Başarıyla Güncellendi!");
        }
    }
}