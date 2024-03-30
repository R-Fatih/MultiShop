using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;

        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
           await _httpClient.PostAsJsonAsync<CreateFeatureDto>("Features",createFeatureDto);
            
        }

        public async Task DeleteFeatureAsync(string FeatureId)
        {
            await _httpClient.GetAsync($"Features/delete/{FeatureId}");
        }

        public async Task<List<ResultFeatureDto>> GetAllFeaturesAsync()
        {
           return await _httpClient.GetFromJsonAsync<List<ResultFeatureDto>>("Features");

        }

        public async Task<UpdateFeatureDto> GetByIdFeatureAsync(string FeatureId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateFeatureDto>($"Features/{FeatureId}");
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            await _httpClient.PostAsJsonAsync<UpdateFeatureDto>("Features/update", updateFeatureDto);
        }
    }
}
