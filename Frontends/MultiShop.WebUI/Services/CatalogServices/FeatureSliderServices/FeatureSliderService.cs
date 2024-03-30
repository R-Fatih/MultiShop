using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
           await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("FeatureSliders",createFeatureSliderDto);
            
        }

        public async Task DeleteFeatureSliderAsync(string FeatureSliderId)
        {
            await _httpClient.GetAsync($"FeatureSliders/delete/{FeatureSliderId}");
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync()
        {
           return await _httpClient.GetFromJsonAsync<List<ResultFeatureSliderDto>>("FeatureSliders");

        }

        public async Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string FeatureSliderId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateFeatureSliderDto>($"FeatureSliders/{FeatureSliderId}");
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _httpClient.PostAsJsonAsync<UpdateFeatureSliderDto>("FeatureSliders/update", updateFeatureSliderDto);
        }
    }
}
