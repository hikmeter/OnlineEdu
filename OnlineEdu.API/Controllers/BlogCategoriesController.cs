using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.BlogCategoryDtos;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoriesController(IBlogCategoryService _blogCategoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _blogCategoryService.GetBlogCategoryList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _blogCategoryService.GetBlogCategoryById(id);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogCategoryService.DeleteBlogCategory(id);
            return Ok("Blog Kategorisi Başarıyla Silindi!");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCategoryDto dto)
        {
            await _blogCategoryService.CreateBlogCategory(dto);
            return Ok("Blog Kategorisi Başarıyla Oluşturuldu!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogCategoryDto dto)
        {
            await _blogCategoryService.UpdateBlogCategory(dto);
            return Ok("Blog Kategorisi Başarıyla Güncellendi!");
        }
    }
}
