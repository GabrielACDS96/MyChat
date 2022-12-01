using MyChat.Chat.Domain.Models;

namespace MyChat.Chat.Domain.Interface
{
    public interface IMessageRepository
    {
        Task<Message[]> Get();
        void Add(Message message);
    }
}
