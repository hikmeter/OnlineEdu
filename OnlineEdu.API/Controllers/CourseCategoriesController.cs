using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.CourseCategoryDtos;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoriesController(ICourseCategoryService _categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _categoryService.GetCourseCategoryList();
            return Ok(values);
        }

        [HttpGet("GetActiveCourses")]
        public async Task<IActionResult> GetActiveCourseCategories()
        {
            var values = await _categoryService.GetActiveCourseCategories();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _categoryService.GetCourseCategoryById(id);
            return Ok(value);
        }

        [HttpGet("ToggleShownStatus/{id}")]
        public async Task<IActionResult> ToggleShownStatus(int id)
        {
            await _categoryService.ToggleShownStatus(id);
            return Ok("Kurs Kategorisi Gösterim Durumu Başarıyla Güncellendi!");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCourseCategory(id);
            return Ok("Kurs Kategorisi Başarıyla Silindi!");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseCategoryDto dto)
        {
            await _categoryService.CreateCourseCategory(dto);
            return Ok("Kurs Kategorisi Başarıyla Oluşturuldu!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCourseCategoryDto dto)
        {
            await _categoryService.UpdateCourseCategory(dto);
            return Ok("Kurs Kategorisi Başarıyla Güncellendi!");
        }
    }
}
