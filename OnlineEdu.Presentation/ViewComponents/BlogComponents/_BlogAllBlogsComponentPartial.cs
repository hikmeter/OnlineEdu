using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Presentation.Dtos.BlogDtos;
using OnlineEdu.Presentation.Helpers;

namespace OnlineEdu.Presentation.ViewComponents.BlogComponents
{
    public class _BlogAllBlogsComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("Blogs/BlogsWithCategoriesAndWriters");
            return View(values);
        }
    }
}
