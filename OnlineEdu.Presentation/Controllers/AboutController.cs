using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.AboutDtos;
using OnlineEdu.Presentation.Helpers;

namespace OnlineEdu.Presentation.Controllers
{
    public class AboutController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultAboutDto>>("Abouts");
            return View(values);
        }
    }
}
