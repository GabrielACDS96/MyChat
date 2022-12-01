using Microsoft.Extensions.Options;
using MyChat.API.Models;
using System.Net;

namespace MyChat.API.Services
{
    public class ChatService : Service
    {
        private readonly HttpClient _httpClient;

        public ChatService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ChatUrl);
        }

        public async Task<Message[]> GetMessages()
        {
            var response = await _httpClient.GetAsync("/api/Message");

            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            return await DeserializarObjetoResponse<Message[]>(response);
        }
    }
}
