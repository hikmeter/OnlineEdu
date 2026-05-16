using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.MessageDtos;
using OnlineEdu.Presentation.Helpers;

namespace OnlineEdu.Presentation.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto dto)
        {
            await _client.PostAsJsonAsync("Messages", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
