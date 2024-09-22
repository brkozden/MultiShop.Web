using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalR.Services;
using MultiShop.SignalR.Services.CommentSignalRService;
using MultiShop.SignalR.Services.MessageSignalRService;

namespace MultiShop.SignalR.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICommentSignalRService _commentSignalRService;
        private readonly IMessageSignalRService _messageSignalRService;

        public SignalRHub(ICommentSignalRService commentSignalRService, IMessageSignalRService messageSignalRService)
        {
            _commentSignalRService = commentSignalRService;
            _messageSignalRService = messageSignalRService;
        }
        public async Task SendStatisticCount(string id)
        {
            var getTotalCommentCount = _commentSignalRService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);

            var getTotalMessageCount = _messageSignalRService.GetTotalMessageCountByReceiverId(id);
            await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);
        }
    }
}
