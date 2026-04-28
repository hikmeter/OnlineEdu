using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Dto.Dtos.SubscriberDtos;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController(ISubscriberService _subscriberService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _subscriberService.GetSubscriberList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _subscriberService.GetSubscriberById(id);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _subscriberService.DeleteSubscriber(id);
            return Ok("Abone Başarıyla Silindi!");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubscriberDto dto)
        {
            try
            {
                await _subscriberService.CreateSubscriber(dto);
                return Ok("Abone Başarıyla Eklendi!");
            }
            catch (FluentValidation.ValidationException ex)
            {
                var errors = ex.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSubscriberDto dto)
        {
            try
            {
                await _subscriberService.UpdateSubscriber(dto);
                return Ok("Abone Başarıyla Güncellendi!");
            }
            catch (FluentValidation.ValidationException ex)
            {
                var errors = ex.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }
        }
    }
}
