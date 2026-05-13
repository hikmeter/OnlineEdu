using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.Presentation.Dtos.BlogCategoryDtos;
using OnlineEdu.Presentation.Dtos.BlogDtos;
using OnlineEdu.Presentation.Helpers;
using System.Security.Claims;

namespace OnlineEdu.Presentation.Areas.Teacher.Controllers
{
    [Authorize(Roles = "Teacher")]
    [Area("Teacher")]
    public class BlogController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        private async Task LoadCategories()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogCategoryDto>>("BlogCategories");
            ViewBag.blogCategories = values.Select(x => new SelectListItem
            {
                Text = x.name,
                Value = x.blogCategoryId.ToString()
            });
        }
        public async Task<IActionResult> Index()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("Blogs/BlogsByWriterId/" + id);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            await LoadCategories();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto dto)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dto.writerId = Convert.ToInt32(id);
            await _client.PostAsJsonAsync("Blogs", dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            await LoadCategories();
            var values = await _client.GetFromJsonAsync<UpdateBlogDto>($"Blogs/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto dto)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dto.writerId = Convert.ToInt32(id);
            await _client.PutAsJsonAsync("Blogs", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
