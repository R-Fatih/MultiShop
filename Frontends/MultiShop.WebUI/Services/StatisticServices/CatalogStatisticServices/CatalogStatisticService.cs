
namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long> GetBrandCount()
        {
            return await _httpClient.GetFromJsonAsync<long>("Statistics/GetBrandCount");
        }

        public async Task<long> GetCategoryCount()
        {
            return await _httpClient.GetFromJsonAsync<long>("Statistics/GetCategoryCount");
        }

        public async Task<string> GetMaxPriceProductName()
        {
            return await _httpClient.GetStringAsync("Statistics/GetMaxPriceProductName");
        }

        public async Task<string> GetMinPriceProductName()
        {
            return await _httpClient.GetStringAsync("Statistics/GetMinPriceProductName");
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            return await _httpClient.GetFromJsonAsync<decimal>("Statistics/GetProductAvgPrice");
        }

        public async Task<long> GetProductCount()
        {
            return await _httpClient.GetFromJsonAsync<long>("Statistics/GetProductCount");
        }
    }
}
