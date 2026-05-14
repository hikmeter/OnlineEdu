using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Services.UserServices;

namespace OnlineEdu.Presentation.ViewComponents.HomeComponents
{
    public class _HomeTeachersComponentPartial(IUserService _service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _service.GetAllTeachers();
            return View(values);
        }
    }
}
