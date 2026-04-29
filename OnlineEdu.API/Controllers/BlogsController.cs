using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.BlogDtos;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IBlogService _blogService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _blogService.GetBlogList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _blogService.GetBlogById(id);
            return Ok(value);
        }

        [HttpGet("BlogsWithCategories")]
        public async Task<IActionResult> GetWithCategories()
        {
            var values = await _blogService.GetAllBlogsWithCategories();
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.DeleteBlog(id);
            return Ok("Blog Başarıyla Silindi!");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogDto dto)
        {
            try
            {
                await _blogService.CreateBlog(dto);
                return Ok("Blog Başarıyla Oluşturuldu!");
            }
            catch (FluentValidation.ValidationException ex)
            {
                var errors = ex.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(errors);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogDto dto)
        {
            try
            {
                await _blogService.UpdateBlog(dto);
                return Ok("Blog Başarıyla Güncellendi!");
            }
            catch (FluentValidation.ValidationException ex)
            {
                var errors = ex.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(errors);
            }
        }
    }
}
