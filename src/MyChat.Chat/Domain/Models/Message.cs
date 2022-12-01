namespace MyChat.Chat.Domain.Models
{
    public class Message
    {
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Text { get; private set; }
        public DateTime TimeSpan { get; private set; }

        protected Message() { }

        public Message(string userName, string text, DateTime? timeSpan = null)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            Text = text;
            TimeSpan = timeSpan ?? DateTime.Now;
        }
    }
}
