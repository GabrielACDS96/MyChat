using Microsoft.EntityFrameworkCore;
using MyChat.Chat.Domain.Models;

namespace MyChat.Chat.Infra.Data.Context
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }
    }
}
