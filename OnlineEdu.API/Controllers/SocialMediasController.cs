using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.SocialMediaDtos;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController(ISocialMediaService _mediaService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _mediaService.GetSocialMediaList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _mediaService.GetSocialMediaById(id);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediaService.DeleteSocialMedia(id);
            return Ok("Sosyal Medya Alanı Başarıyla Silindi!");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaDto dto)
        {
            await _mediaService.CreateSocialMedia(dto);
            return Ok("Sosyal Medya Alanı Başarıyla Oluşturuldu!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSocialMediaDto dto)
        {
            await _mediaService.UpdateSocialMedia(dto);
            return Ok("Sosyal Medya Alanı Başarıyla Güncellendi!");
        }
    }
}
