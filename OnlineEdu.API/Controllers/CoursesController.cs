using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.CourseDtos;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(ICourseService _courseService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _courseService.GetCourseList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _courseService.GetCourseById(id);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseService.DeleteCourse(id);
            return Ok("Kurs Başarıyla Silindi!");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseDto dto)
        {
            await _courseService.CreateCourse(dto);
            return Ok("Kurs Başarıyla Oluşturuldu!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCourseDto dto)
        {
            await _courseService.UpdateCourse(dto);
            return Ok("Kurs Başarıyla Güncellendi!");
        }
    }
}
