namespace MultiShop.SignalRRealTimeApi.Services.SignalRCommentServices
{
    public class SignalRCommentService : ISignalRCommentService
    {
        private readonly HttpClient _httpClient;

        public SignalRCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

      
        public async Task<int> GetTotalCommentCount()
        {
            return await _httpClient.GetFromJsonAsync<int>($"https://localhost:7153/api/Comments/GetTotalCommentCount");
        }
    }
}
