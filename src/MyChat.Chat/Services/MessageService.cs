using EasyNetQ;
using MyChat.API.Messages;
using MyChat.Chat.Infra.Data.Repository;

namespace MyChat.Chat.Services
{
    public class MessageService : BackgroundService
    {
        private readonly IBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public MessageService(IBus bus, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus.PubSub.SubscribeAsync<MessageCommand>("MessageReceived", request => CreateMessage(request));
            return Task.CompletedTask;
        }

        private void CreateMessage(MessageCommand messageCommand)
        {
            using var scope = _serviceProvider.CreateScope();
            var messageRepository = scope.ServiceProvider.GetRequiredService<MessageRepository>();
            var message = new Domain.Models.Message(messageCommand.UserName, messageCommand.Text);
            messageRepository.Add(message);
        }
    }
}
