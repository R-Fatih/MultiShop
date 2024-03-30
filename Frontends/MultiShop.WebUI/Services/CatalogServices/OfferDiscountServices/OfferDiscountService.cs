using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly HttpClient _httpClient;

        public OfferDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
           await _httpClient.PostAsJsonAsync<CreateOfferDiscountDto>("OfferDiscounts",createOfferDiscountDto);
            
        }

        public async Task DeleteOfferDiscountAsync(string OfferDiscountId)
        {
            await _httpClient.GetAsync($"OfferDiscounts/delete/{OfferDiscountId}");
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountsAsync()
        {
           return await _httpClient.GetFromJsonAsync<List<ResultOfferDiscountDto>>("OfferDiscounts");

        }

        public async Task<UpdateOfferDiscountDto> GetByIdOfferDiscountAsync(string OfferDiscountId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateOfferDiscountDto>($"OfferDiscounts/{OfferDiscountId}");
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _httpClient.PostAsJsonAsync<UpdateOfferDiscountDto>("OfferDiscounts/update", updateOfferDiscountDto);
        }
    }
}
