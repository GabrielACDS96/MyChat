namespace MyChat.API.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime TimeSpan { get; set; }
    }
}
