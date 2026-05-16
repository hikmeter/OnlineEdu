using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.ContactDtos;
using OnlineEdu.Presentation.Helpers;

namespace OnlineEdu.Presentation.ViewComponents.ContactComponents
{
    public class _ContactInfoComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("Contacts");
            return View(values);
        }
    }
}
