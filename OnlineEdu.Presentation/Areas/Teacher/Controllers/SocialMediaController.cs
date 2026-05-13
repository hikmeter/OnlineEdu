using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.Presentation.Dtos.SocialMediaDtos;
using OnlineEdu.Presentation.Dtos.TeacherSocialDtos;
using OnlineEdu.Presentation.Helpers;
using System.Security.Claims;

namespace OnlineEdu.Presentation.Areas.Teacher.Controllers
{
    [Authorize(Roles = "Teacher")]
    [Area("Teacher")]
    public class SocialMediaController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        private async Task LoadSocialMedias()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("SocialMedias");
            ViewBag.socialMedias = values.Select(x => new SelectListItem
            {
                Text = x.title,
                Value = x.socialMediaId.ToString()
            });
        }
        public async Task<IActionResult> Index()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var values = await _client.GetFromJsonAsync<List<ResultTeacherSocialDto>>("TeacherSocials/GetTeacherSocialsByTeacherId/" + id);
            return View(values);
        }

        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await _client.DeleteAsync($"TeacherSocials/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> CreateSocialMedia()
        {
            await LoadSocialMedias();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateTeacherSocialDto dto)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dto.teacherId = Convert.ToInt32(id);
            await _client.PostAsJsonAsync("TeacherSocials", dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            await LoadSocialMedias();
            var values = await _client.GetFromJsonAsync<UpdateTeacherSocialDto>($"TeacherSocials/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateTeacherSocialDto dto)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dto.teacherId = Convert.ToInt32(id);
            await _client.PutAsJsonAsync("TeacherSocials", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
