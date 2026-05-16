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

        [HttpGet("BlogsWithCategoriesAndWriters")]
        public async Task<IActionResult> GetWithCategoriesAndWriters()
        {
            var values = await _blogService.GetAllBlogsWithCategoriesAndWriters();
            return Ok(values);

        }

        [HttpGet("Last4BlogsWithCategoriesAndWriters")]
        public async Task<IActionResult> GetLast4BlogsWithCategoriesAndWriters()
        {
            var values = await _blogService.GetLast4BlogsWithCategoriesAndWriters();
            return Ok(values);
        }

        [HttpGet("BlogsByWriterId/{id}")]
        public async Task<IActionResult> GetBlogsByWriterId(int id)
        {
            var values = await _blogService.GetBlogsByWriterId(id);
            return Ok(values);
        }

        [HttpGet("BlogsByCategoryId/{id}")]
        public async Task<IActionResult> GetBlogsByCategoryId(int id)
        {
            var values = await _blogService.GetBlogsByCategoryId(id);
            return Ok(values);
        }

        [HttpGet("BlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var value = await _blogService.GetBlogCount();
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.DeleteBlog(id);
            return Ok("Blog Başarıyla Silindi!");
        }

        [HttpGet("BlogWithCategoryAndWriterByBlogId/{id}")]
        public async Task<IActionResult> GetBlogWithCategoryAndWriterByBlogId(int id)
        {
            var values = await _blogService.GetBlogWithCategoryAndWriterByBlogId(id);
            return Ok(values);

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
