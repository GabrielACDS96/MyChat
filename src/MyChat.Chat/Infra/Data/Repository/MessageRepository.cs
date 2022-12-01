using Microsoft.EntityFrameworkCore;
using MyChat.Chat.Infra.Data.Context;
using MyChat.Chat.Domain.Interface;
using MyChat.Chat.Domain.Models;

namespace MyChat.Chat.Infra.Data.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ChatContext db;
        public MessageRepository(ChatContext context)
        {
            db = context;
        }

        public void Add(Message message)
        {
            db.Messages.Add(message);
            db.SaveChanges();
        }

        public Task<Message[]> Get()
        {
            return db.Messages.ToArrayAsync();
        }
    }
}
