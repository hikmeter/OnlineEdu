using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.MessageDtos;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController(IMessageService _messageService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _messageService.GetMessageList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _messageService.GetMessageById(id);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _messageService.DeleteMessage(id);
            return Ok("Mesaj Başarıyla Silindi!");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMessageDto dto)
        {
            await _messageService.CreateMessage(dto);
            return Ok("Mesaj Başarıyla Oluşturuldu!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMessageDto dto)
        {
            await _messageService.UpdateMessage(dto);
            return Ok("Mesaj Başarıyla Güncellendi!");
        }
    }
}
