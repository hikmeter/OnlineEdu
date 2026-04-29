using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.BannerDtos;
using OnlineEdu.Presentation.Helpers;

namespace OnlineEdu.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BannerController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBannerDto>>("Banners");
            return View(values);
        }

        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _client.DeleteAsync($"Banners/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto dto)
        {
            await _client.PostAsJsonAsync("Banners", dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateBannerDto>($"Banners/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto dto)
        {
            await _client.PutAsJsonAsync("Banners", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
