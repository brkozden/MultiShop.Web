using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutHeaderComponentPartial:ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly ICommentStatisticService _commentStatisticService;

        public _AdminLayoutHeaderComponentPartial(IMessageService messageService, IUserService userService, ICommentStatisticService commentStatisticService)
        {
            _messageService = messageService;
            _userService = userService;
            _commentStatisticService = commentStatisticService;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var user = await _userService.GetUserInfo();
            string id = user.Id;
            int messageCount = await _messageService.GetTotalMessageCountByReceiverId(id);
            int commentCount = await _commentStatisticService.GetTotalCommentCount();
            ViewBag.messageCount = messageCount;
            ViewBag.commentCount = commentCount;
            return View(messageCount); 
        }
    }
}
