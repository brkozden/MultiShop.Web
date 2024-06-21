using MultiShop.Dtos.IdentityDtos.LoginDto;

namespace MultiShop.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signInDto);
        Task<bool> GetRefreshToken();

    }
}
