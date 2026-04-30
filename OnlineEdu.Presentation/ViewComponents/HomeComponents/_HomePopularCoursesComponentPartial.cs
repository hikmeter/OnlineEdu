using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.CourseDtos;
using OnlineEdu.Presentation.Helpers;

namespace OnlineEdu.Presentation.ViewComponents.HomeComponents
{
    public class _HomePopularCoursesComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("Courses/3ActivePopularCourses");
            return View(values);
        }
    }
}
