using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.Presentation.Dtos.BlogCategoryDtos;
using OnlineEdu.Presentation.Dtos.BlogDtos;
using OnlineEdu.Presentation.Helpers;
using System.Text.Json;

namespace OnlineEdu.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BlogController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        private async Task LoadCategories()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogCategoryDto>>("BlogCategories");

            ViewBag.categoryList = values.Select(x => new SelectListItem
            {
                Text = x.name,
                Value = x.blogCategoryId.ToString()
            }).ToList();

        }
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("Blogs/BlogsWithCategories");
            return View(values);
        }

        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _client.DeleteAsync($"Blogs/{id}");
            return RedirectToAction(nameof(Index));
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
            var response = await _client.PostAsJsonAsync("Blogs", dto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            var content = await response.Content.ReadAsStringAsync();
            var errors = JsonSerializer.Deserialize<List<string>>(content);
            foreach (var error in errors)
            {
                ModelState.AddModelError("", error);
            }
            await LoadCategories();
            return View();
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
            var response = await _client.PutAsJsonAsync("Blogs", dto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            var content = await response.Content.ReadAsStringAsync();
            var errors = JsonSerializer.Deserialize<List<string>>(content);
            foreach (var error in errors)
            {
                ModelState.AddModelError("", error);
            }
            await LoadCategories();
            return View();
        }
    }
}
