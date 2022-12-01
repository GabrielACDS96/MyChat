using Microsoft.EntityFrameworkCore;
using MyChat.Chat.Infra.Data.Context;

namespace MyChat.Chat.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ChatContext>(options => options.UseInMemoryDatabase("ChatDb"));
        }
    }
}
