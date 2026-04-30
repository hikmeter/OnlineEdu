using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.CourseCategoryDtos;
using OnlineEdu.Presentation.Helpers;

namespace OnlineEdu.Presentation.ViewComponents.HomeComponents
{
    public class _HomeCourseCategoriesComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("CourseCategories/GetActiveCourses");
            return View(values);
        }
    }
}
