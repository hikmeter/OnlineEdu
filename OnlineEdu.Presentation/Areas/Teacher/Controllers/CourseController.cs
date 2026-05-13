using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.Presentation.Dtos.CourseCategoryDtos;
using OnlineEdu.Presentation.Dtos.CourseDtos;
using OnlineEdu.Presentation.Helpers;
using System.Security.Claims;

namespace OnlineEdu.Presentation.Areas.Teacher.Controllers
{
    [Authorize(Roles = "Teacher")]
    [Area("Teacher")]
    public class CourseController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        private async Task LoadCategories()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("CourseCategories");
            ViewBag.courseCategories = values.Select(x => new SelectListItem
            {
                Value = x.courseCategoryId.ToString(),
                Text = x.categoryName
            }).ToList();
        }
        public async Task<IActionResult> Index()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("Courses/CoursesByTeacherId/" + id);
            return View(values);
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
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dto.AppUserId = Convert.ToInt32(id);
            await _client.PostAsJsonAsync<CreateCourseDto>("Courses", dto);
            return RedirectToAction(nameof(Index));
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
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dto.AppUserId = Convert.ToInt32(id);
            await _client.PutAsJsonAsync<UpdateCourseDto>("Courses", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
