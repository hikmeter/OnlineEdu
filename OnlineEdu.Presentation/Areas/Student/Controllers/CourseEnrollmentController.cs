using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.CourseDtos;
using OnlineEdu.Presentation.Dtos.CourseEnrollmentDtos;
using OnlineEdu.Presentation.Helpers;
using System.Security.Claims;

namespace OnlineEdu.Presentation.Areas.Student.Controllers
{
    [Authorize(Roles = "Student")]
    [Area("Student")]
    public class CourseEnrollmentController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var values = await _client.GetFromJsonAsync<List<ResultCourseEnrollmentDto>>("CourseEnrollments/WithCourseNames/" + id);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCourseEnrollment()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("Courses/CoursesWithCategories");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseEnrollment(int courseId)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dto = new CreateCourseEnrollmentDto
            {
                appUserId = Convert.ToInt32(id),
                courseId = courseId
            };
            await _client.PostAsJsonAsync("CourseEnrollments", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
