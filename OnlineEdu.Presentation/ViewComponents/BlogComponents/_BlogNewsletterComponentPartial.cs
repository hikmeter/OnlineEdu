using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.Presentation.ViewComponents.BlogComponents
{
    public class _BlogNewsletterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
