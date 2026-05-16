using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.Presentation.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
