namespace MultiShop.SignalR.Services.MessageSignalRService
{
    public interface IMessageSignalRService
    {
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
