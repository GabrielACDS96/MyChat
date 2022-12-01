using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyChat.Robot.Services;

namespace MyChat.Robot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockService stockService;
        public StockController(StockService stockService)
        {
            this.stockService = stockService;
        }

        [HttpGet]
        public async Task<string> Get([FromQuery] string stockCode)
        {
            return await stockService.GetStockQuota(stockCode);
        }
    }
}
