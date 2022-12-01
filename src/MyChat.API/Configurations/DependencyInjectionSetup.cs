using EasyNetQ;
using MyChat.API.Services;

namespace MyChat.API.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ChatService>();
            services.AddSingleton<IBus>(RabbitHutch.CreateBus(configuration.GetSection("MessageQueueConnection")["MessageBus"]));
        }
    }
}
