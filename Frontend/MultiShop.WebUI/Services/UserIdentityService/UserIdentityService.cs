using MultiShop.Dtos.IdentityDtos.UserDto;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.UserIdentityService
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly HttpClient _httpClient;

        public UserIdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ResultUserDto>> GetAllUsersAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5001/api/users/getalluserlist");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultUserDto>>(jsonData);
            return values;
        }
    }
}
