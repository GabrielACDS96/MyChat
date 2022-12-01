using Microsoft.AspNetCore.Mvc;
using MyChat.Chat.Domain.Interface;
using MyChat.Chat.Domain.Models;

namespace MyChat.Chat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet]
        public async Task<Message[]> Get()
        {
            return await _messageRepository.Get();
        }

        [HttpPost]
        public IActionResult Post()
        {
            var message = new Message("UserName", "Texto");
            _messageRepository.Add(message);
            return Ok(message);
        }
    }
}
