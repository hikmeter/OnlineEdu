using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.ContactDtos;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IContactService _contactService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _contactService.GetContactList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _contactService.GetContactById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactService.DeleteContact(id);
            return Ok("İletişim Alanı Başarıyla Silindi!");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto dto)
        {
            await _contactService.CreateContact(dto);
            return Ok("İletişim Alanı Başarıyla Oluşturuldu!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactDto dto)
        {
            await _contactService.UpdateContact(dto);
            return Ok("İletişim Alanı Başarıyla Güncellendi!");
        }
    }
}
