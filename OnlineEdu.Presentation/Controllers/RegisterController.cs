using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.UserDtos;
using OnlineEdu.Presentation.Services.UserServices;

namespace OnlineEdu.Presentation.Controllers
{
    public class RegisterController(IUserService _userService) : Controller
    {
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(UserRegisterDto dto)
        {
            var result = await _userService.CreateUserAsync(dto);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
