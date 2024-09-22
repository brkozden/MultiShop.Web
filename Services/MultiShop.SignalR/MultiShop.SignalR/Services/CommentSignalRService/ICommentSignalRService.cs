namespace MultiShop.SignalR.Services.CommentSignalRService
{
    public interface ICommentSignalRService
    {
        Task<int> GetTotalCommentCount();
    }
}
