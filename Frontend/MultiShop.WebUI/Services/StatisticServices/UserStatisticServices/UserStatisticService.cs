﻿
namespace MultiShop.WebUI.Services.StatisticServices.UserStatisticServices
{
    public class UserStatisticService : IUserStatisticService
    {
        private readonly HttpClient _httpClient;

        public UserStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetUserCount()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5001/Api/Statistics");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
