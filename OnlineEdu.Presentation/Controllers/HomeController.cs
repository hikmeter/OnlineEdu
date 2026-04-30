using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
