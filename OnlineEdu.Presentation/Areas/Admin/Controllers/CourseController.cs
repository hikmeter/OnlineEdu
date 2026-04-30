using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.Presentation.Dtos.CourseCategoryDtos;
using OnlineEdu.Presentation.Dtos.CourseDtos;
using OnlineEdu.Presentation.Helpers;
using System.Text.Json;

namespace OnlineEdu.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CourseController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        private async Task LoadCategories()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("CourseCategories");
            ViewBag.categoryList = values.Select(x => new SelectListItem
            {
                Text = x.categoryName,
                Value = x.courseCategoryId.ToString()
            }).ToList();
        }
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("Courses/CoursesWithCategories");
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> ToggleShownStatus(int id)
        {
            await _client.GetAsync($"Courses/ToggleShownStatus/{id}");
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _client.DeleteAsync($"Courses/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> CreateCourse()
        {
            await LoadCategories();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDto dto)
        {
            var response = await _client.PostAsJsonAsync("Courses", dto);
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
        public async Task<IActionResult> UpdateCourse(int id)
        {
            await LoadCategories();
            var values = await _client.GetFromJsonAsync<UpdateCourseDto>($"Courses/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCourse(UpdateCourseDto dto)
        {
            var response = await _client.PutAsJsonAsync("Courses", dto);
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
