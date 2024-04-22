using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderingServices
{
    public class OrderOrderingService : IOrderOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderOrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string userId)
        {
        return await _httpClient.GetFromJsonAsync<List<ResultOrderingByUserIdDto>>($"Orderings/GetOrderingByUserId?userId={userId}");
        }
    }
}
