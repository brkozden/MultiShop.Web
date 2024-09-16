using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public MessagesController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessage()
        {
            var values = await _userMessageService.GetAllMessageAsync();
            return Ok(values);
        }
        [HttpGet("GetMessageByIdAsync/{id}")]
        public async Task<IActionResult> GetMessageByIdAsync(int id)
        {
            var values = await _userMessageService.GetByIdMessageAsync(id);
            return Ok(values);
        }
        [HttpGet("GetSendboxMessageAsync")]
        public async Task<IActionResult> GetSendboxMessageAsync(string id)
        {
            var values = await _userMessageService.GetSendboxMessageAsync(id);
            return Ok(values);
        }
        [HttpGet("GetInboxMessageAsync")]
        public async Task<IActionResult> GetInboxMessageAsync(string id)
        {
            var values = await _userMessageService.GetInboxMessageAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            await _userMessageService.CreateMessageAsync(createMessageDto);
            return Ok("Yeni Mesaj Eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageAsync(int id)
        {
            await _userMessageService.DeleteMessageAsync(id);
            return Ok("Mesaj Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            await _userMessageService.UpdateMessageAsync(updateMessageDto);
            return Ok("Mesaj Güncellendi.");
        }
    }
}
