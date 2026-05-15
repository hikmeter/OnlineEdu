using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.AppUserDtos;
using OnlineEdu.Presentation.Helpers;

namespace OnlineEdu.Presentation.Controllers
{
    public class TeacherController : Controller
    {
        private HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultAppUserDto>>("AppUsers/GetAllTeachers");
            return View(values);
        }
    }
}
