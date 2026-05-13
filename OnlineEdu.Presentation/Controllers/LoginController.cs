using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.UserDtos;
using OnlineEdu.Presentation.Services.UserServices;

namespace OnlineEdu.Presentation.Controllers
{
    public class LoginController(IUserService _userService) : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto dto)
        {
            var result = await _userService.LoginAsync(dto);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", result.ErrorMessage);
                return View();
            }
            return result.Role switch
            {
                "Admin" => RedirectToAction("Index", "About", new { area = "Admin" }),
                "Teacher" => RedirectToAction("Index", "Teacher"),
                _ => RedirectToAction("Index", "Student")
            };
        }
    }
}
