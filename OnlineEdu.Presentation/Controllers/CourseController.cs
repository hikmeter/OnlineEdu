using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.CourseDtos;
using OnlineEdu.Presentation.Helpers;

namespace OnlineEdu.Presentation.Controllers
{
    public class CourseController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("Courses");
            return View(values);
        }

        public async Task<IActionResult> GetCoursesByCategoryId(int id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("Courses/CoursesByCategoryId/" + id);
            return View(values);
        }
    }
}
