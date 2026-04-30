using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.MessageDtos;
using OnlineEdu.Presentation.Helpers;

namespace OnlineEdu.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MessageController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultMessageDto>>("Messages");
            return View(values);
        }

        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _client.DeleteAsync($"Messages/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ReadMessage(int id)
        {
            var value = await _client.GetFromJsonAsync<GetMessageByIdDto>("Messages/" + id);
            return View(value);
        }
    }
}
