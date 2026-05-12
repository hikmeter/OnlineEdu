using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.RoleDtos;
using OnlineEdu.Presentation.Services.RoleServices;

namespace OnlineEdu.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class RoleController(IRoleService _service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _service.GetAllRolesAsync();
            return View(values);
        }

        public IActionResult DeleteRole(int id)
        {
            _service.DeleteRoleAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto dto)
        {
            await _service.CreateRoleAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var value = await _service.GetRoleByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto dto)
        {
            await _service.UpdateRoleAsync(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
