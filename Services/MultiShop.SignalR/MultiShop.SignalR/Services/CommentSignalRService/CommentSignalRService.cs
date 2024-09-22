
using System.Net.Http;

namespace MultiShop.SignalR.Services.CommentSignalRService
{
    public class CommentSignalRService : ICommentSignalRService
    {
        private readonly HttpClient _httpClient;

        public CommentSignalRService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetTotalCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("comments/GetTotalCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
