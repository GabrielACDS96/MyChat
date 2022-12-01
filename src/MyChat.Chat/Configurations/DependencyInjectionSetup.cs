using EasyNetQ;
using MyChat.Chat.Infra.CrossCutting;
using MyChat.Chat.Services;

namespace MyChat.Chat.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
            services.AddSingleton<IBus>(RabbitHutch.CreateBus(configuration.GetSection("MessageQueueConnection")["MessageBus"]));
            services.AddHostedService<MessageService>();
        }
    }
}
