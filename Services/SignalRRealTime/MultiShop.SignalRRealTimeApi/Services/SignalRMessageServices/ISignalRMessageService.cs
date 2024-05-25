namespace MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> GetMessageCountByReseriverIdAsync(string receiverId);
    }
}
