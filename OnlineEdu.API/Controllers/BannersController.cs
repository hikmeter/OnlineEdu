using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.BannerDtos;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IBannerService _bannerService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _bannerService.GetBannerList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _bannerService.GetBannerById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bannerService.DeleteBanner(id);
            return Ok("Afiş Alanı Başarıyla Silindi!");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerDto dto)
        {
            await _bannerService.CreateBanner(dto);
            return Ok("Afiş Alanı Başarıyla Oluşturuldu!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBannerDto dto)
        {
            await _bannerService.UpdateBanner(dto);
            return Ok("Afiş Alanı Başarıyla Güncellendi!");
        }
    }
}
