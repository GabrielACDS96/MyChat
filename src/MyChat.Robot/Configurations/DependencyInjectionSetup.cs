using EasyNetQ;
using MyChat.Robot.Services;

namespace MyChat.Robot.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHostedService<StockService>();
            services.AddSingleton<IBus>(RabbitHutch.CreateBus(configuration.GetSection("MessageQueueConnection")["MessageBus"]));
        }
    }
}
