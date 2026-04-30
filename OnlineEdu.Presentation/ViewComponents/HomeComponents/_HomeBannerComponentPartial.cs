using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.BannerDtos;
using OnlineEdu.Presentation.Helpers;

namespace OnlineEdu.Presentation.ViewComponents.HomeComponents
{
    public class _HomeBannerComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBannerDto>>("Banners");
            return View(values);
        }
    }
}
