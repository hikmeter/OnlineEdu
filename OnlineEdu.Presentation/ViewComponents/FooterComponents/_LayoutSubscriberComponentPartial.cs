using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.Presentation.ViewComponents.FooterComponents
{
    public class _LayoutSubscriberComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
