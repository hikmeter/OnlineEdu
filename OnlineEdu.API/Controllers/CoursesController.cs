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

        [HttpGet("CoursesWithCategories")]
        public async Task<IActionResult> GetCoursesWithCategories()
        {
            var values = await _courseService.GetCoursesWithCategories();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _courseService.GetCourseById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseService.DeleteCourse(id);
            return Ok("Kurs Başarıyla Silindi!");
        }

        [HttpGet("ToggleShownStatus/{id}")]
        public async Task<IActionResult> ToggleShownStatus(int id)
        {
            var values = await _courseService.ToggleShownStatus(id);
            return Ok("Kurs Gösterim Durumu Başarıyla Güncellendi!");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseDto dto)
        {
            try
            {
                await _courseService.CreateCourse(dto);
                return Ok("Kurs Başarıyla Oluşturuldu!");
            }
            catch (FluentValidation.ValidationException ex)
            {
                var errors = ex.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCourseDto dto)
        {
            try
            {
                await _courseService.UpdateCourse(dto);
                return Ok("Kurs Başarıyla Güncellendi!");
            }
            catch (FluentValidation.ValidationException ex)
            {
                var errors = ex.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }
        }
    }
}
