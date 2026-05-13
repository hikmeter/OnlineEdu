using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.TeacherSocialDtos;
using OnlineEdu.Presentation.Helpers;

namespace OnlineEdu.Presentation.ViewComponents.HomeComponents
{
    public class _HomeTeachersComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultTeacherSocialDto>>("TeacherSocials");
            return View(values);
        }
    }
}
