namespace MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices
{
    public class SignalRMessageService : ISignalRMessageService
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetMessageCountByReseriverIdAsync(string receiverId)
        {
            return await _httpClient.GetFromJsonAsync<int>($"UserMessage/GetMessageCountByReceiverId?receiverId={receiverId}");

        }

    }
}
