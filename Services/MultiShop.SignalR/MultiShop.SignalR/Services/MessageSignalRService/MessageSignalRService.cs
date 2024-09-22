
using System.Net.Http;

namespace MultiShop.SignalR.Services.MessageSignalRService
{
    public class MessageSignalRService : IMessageSignalRService
    {
        private readonly HttpClient _httpClient;

        public MessageSignalRService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("messages/GetTotalMessageCountByReceiverId?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
