using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Index()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("Courses/CoursesByTeacherId/" + id);
            return View(values);
        }
    }
}
