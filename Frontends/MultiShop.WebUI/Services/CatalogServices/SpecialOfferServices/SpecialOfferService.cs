using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
           await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("SpecialOffers",createSpecialOfferDto);
            
        }

        public async Task DeleteSpecialOfferAsync(string SpecialOfferId)
        {
            await _httpClient.GetAsync($"SpecialOffers/delete/{SpecialOfferId}");
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync()
        {
           return await _httpClient.GetFromJsonAsync<List<ResultSpecialOfferDto>>("SpecialOffers");

        }

        public async Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string SpecialOfferId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateSpecialOfferDto>($"SpecialOffers/{SpecialOfferId}");
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _httpClient.PostAsJsonAsync<UpdateSpecialOfferDto>("SpecialOffers/update", updateSpecialOfferDto);
        }
    }
}
