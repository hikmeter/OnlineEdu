using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.TeacherSocialDtos;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherSocialsController(ITeacherSocialService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _service.GetTeacherSocialList();
            return Ok(values);
        }

        [HttpGet("GetTeacherSocialsByTeacherId/{id}")]
        public async Task<IActionResult> GetTeacherSocialsByTeacherId(int id)
        {
            var value = await _service.GetTeacherSocialsByTeacherId(id);
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _service.GetTeacherSocialById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteTeacherSocial(id);
            return Ok("Sosyal Medya Alanı Başarıyla Silindi!");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeacherSocialDto dto)
        {
            await _service.CreateTeacherSocial(dto);
            return Ok("Sosyal Medya Alanı Başarıyla Oluşturuldu!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTeacherSocialDto dto)
        {
            await _service.UpdateTeacherSocial(dto);
            return Ok("Sosyal Medya Alanı Başarıyla Güncellendi!");
        }
    }
}
