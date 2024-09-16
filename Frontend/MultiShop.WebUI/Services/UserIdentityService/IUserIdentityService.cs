using MultiShop.Dtos.IdentityDtos.UserDto;

namespace MultiShop.WebUI.Services.UserIdentityService
{
    public interface IUserIdentityService
    {
        Task<List<ResultUserDto>> GetAllUsersAsync();
    }
}
