using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.BlogDtos;
using OnlineEdu.Presentation.Dtos.SubscriberDtos;
using OnlineEdu.Presentation.Helpers;

namespace OnlineEdu.Presentation.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(CreateSubscriberDto dto)
        {
            await _client.PostAsJsonAsync("Subscribers", dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> BlogDetail(int id)
        {
            var value = await _client.GetFromJsonAsync<ResultBlogDto>("Blogs/BlogWithCategoryAndWriterByBlogId/" + id);
            return View(value);
        }

        [HttpGet]
        public async Task<IActionResult> BlogsByCategoryId(int id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("Blogs/BlogsByCategoryId/" + id);
            return View(values);
        }
    }
}
