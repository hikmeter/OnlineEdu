using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.BlogCategoryDtos;
using OnlineEdu.Presentation.Helpers;

namespace OnlineEdu.Presentation.ViewComponents.BlogComponents
{
    public class _BlogCategoryListComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<BlogCategoriesWithBlogCountDto>>("BlogCategories/WithBlogCount");
            return View(values);
        }
    }
}
