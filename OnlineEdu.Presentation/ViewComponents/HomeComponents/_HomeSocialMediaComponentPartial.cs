using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.SocialMediaDtos;
using OnlineEdu.Presentation.Helpers;

namespace OnlineEdu.Presentation.ViewComponents.HomeComponents
{
    public class _HomeSocialMediaComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("SocialMedias");
            return View(values);
        }
    }
}
