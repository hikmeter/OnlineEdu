using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.UserDtos;
using OnlineEdu.Presentation.Services.UserServices;

namespace OnlineEdu.Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RoleAssignController(IUserService _service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _service.GetAllUsersAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            ViewBag.UserId = id;
            var values = await _service.GetAssignRoleListAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(int id, List<AssignRoleDto> dtos)
        {
            await _service.AssignRoleAsync(id, dtos);
            return RedirectToAction(nameof(Index));
        }
    }
}
