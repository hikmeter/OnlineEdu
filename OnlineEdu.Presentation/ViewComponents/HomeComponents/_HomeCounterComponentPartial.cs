using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Helpers;
using OnlineEdu.Presentation.Services.UserServices;

namespace OnlineEdu.Presentation.ViewComponents.HomeComponents
{
    public class _HomeCounterComponentPartial(IUserService _service) : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.blogCount = await _client.GetFromJsonAsync<int>("Blogs/BlogCount");
            ViewBag.courseCount = await _client.GetFromJsonAsync<int>("Courses/CourseCount");
            ViewBag.teacherCount = await _service.GetTeachersCount();
            ViewBag.studentCount = await _service.GetStudentsCount();
            return View();
        }
    }
}
