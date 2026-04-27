using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.AboutDtos;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IAboutService _aboutService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _aboutService.GetAboutList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _aboutService.GetAboutById(id);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _aboutService.DeleteAbout(id);
            return Ok("Hakkımızda Alanı Başarıyla Silindi!");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto dto)
        {
            await _aboutService.CreateAbout(dto);
            return Ok("Hakkımızda Alanı Başarıyla Oluşturuldu!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutDto dto)
        {
            await _aboutService.UpdateAbout(dto);
            return Ok("Hakkımızda Alanı Başarıyla Güncellendi!");
        }
    }
}
