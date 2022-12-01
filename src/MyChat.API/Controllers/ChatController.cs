using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using MyChat.API.Messages;
using MyChat.API.Models;
using MyChat.API.Services;
using MyChat.Robot.Messages;

namespace MyChat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatService chatService;
        private readonly IBus _bus;

        public ChatController(ChatService chatService, IBus bus)
        {
            this.chatService = chatService;
            _bus = bus;
        }

        [HttpGet("Messages")]
        public async Task<Message[]> GetMessages()
        {
            return await chatService.GetMessages();
        }

        [HttpPost("Messages")]
        public async Task<IActionResult> PostMessage([FromBody]MessageCommand messageCommand)
        {
            await _bus.PubSub.PublishAsync(messageCommand);
            return Ok(messageCommand);
        }

        [HttpGet("StockQuota/{stockCode:string}")]
        public async Task<string> GetStockQuota(string stockCode)
        {
            var stockQuotaCommand = new StockQuotaCommand { StockCode = stockCode };
            var sotckMessage = await _bus.Rpc.RequestAsync<StockQuotaCommand, StockQuotaMessage>(stockQuotaCommand);
            return sotckMessage.Message;
        }
    }
}
