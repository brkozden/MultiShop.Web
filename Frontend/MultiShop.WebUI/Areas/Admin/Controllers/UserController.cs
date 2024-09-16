using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.UserIdentityService;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserIdentityService _userIdentityService;

        public UserController(IUserIdentityService userIdentityService)
        {
            _userIdentityService = userIdentityService;
        }

        public async Task<IActionResult> UserList()
        {
            var userList = await _userIdentityService.GetAllUsersAsync();
            return View(userList);
        }
    }
}
