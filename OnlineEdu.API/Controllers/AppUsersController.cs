using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController(IAppUserService _service) : ControllerBase
    {
        [HttpGet("GetAllTeachers")]
        public async Task<IActionResult> GetAllTeachers()
        {
            var values = await _service.GetAllTeachers();
            return Ok(values);
        }
    }
}
