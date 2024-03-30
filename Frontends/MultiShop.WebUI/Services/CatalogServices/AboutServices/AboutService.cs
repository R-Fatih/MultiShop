using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
           await _httpClient.PostAsJsonAsync<CreateAboutDto>("Abouts",createAboutDto);
            
        }

        public async Task DeleteAboutAsync(string AboutId)
        {
            await _httpClient.GetAsync($"Abouts/delete/{AboutId}");
        }

        public async Task<List<ResultAboutDto>> GetAllAboutsAsync()
        {
           return await _httpClient.GetFromJsonAsync<List<ResultAboutDto>>("Abouts");

        }

        public async Task<UpdateAboutDto> GetByIdAboutAsync(string AboutId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateAboutDto>($"Abouts/{AboutId}");
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PostAsJsonAsync<UpdateAboutDto>("Abouts/update", updateAboutDto);
        }
    }
}
