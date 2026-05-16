using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.Presentation.ViewComponents.ContactComponents
{
    public class _ContactMessageComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
