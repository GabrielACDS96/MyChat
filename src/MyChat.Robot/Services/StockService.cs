using EasyNetQ;
using MyChat.Robot.Messages;
using System.Net;
using System.Net.Http.Headers;

namespace MyChat.Robot.Services
{
    public class StockService : BackgroundService
    {
        private readonly IBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public StockService( IBus bus, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus.Rpc.RespondAsync<StockQuotaCommand, StockQuotaMessage>(async request =>
                new StockQuotaMessage { Message = await GetStockQuota(request.StockCode) });
            return Task.CompletedTask;
        }

        public async Task<string> GetStockQuota(string stockCode)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var httpClient = scope.ServiceProvider.GetRequiredService<HttpClient>();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/csv"));
                var response = await httpClient.GetAsync($"https://stooq.com/q/l/?s={stockCode}&f=sd2t2ohlcv&h&e=csv");
                if (response.StatusCode == HttpStatusCode.NotFound) return null;
                var message = string.Empty;
                using (var s = await response.Content.ReadAsStreamAsync())
                using (var sr = new StreamReader(s))
                {
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var values = line.Split(',');
                        message += $"{values[0]} quota is ${values[4]} per share\n";
                    }
                }
                return message;
            }
        }
    }
}
