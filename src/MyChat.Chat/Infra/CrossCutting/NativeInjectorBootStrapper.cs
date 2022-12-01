using MyChat.Chat.Domain.Interface;
using MyChat.Chat.Infra.Data.Context;
using MyChat.Chat.Infra.Data.Repository;

namespace MyChat.Chat.Infra.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<ChatContext>();
        }
    }
}
