using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
           await _httpClient.PostAsJsonAsync<CreateBrandDto>("Brands",createBrandDto);
            
        }

        public async Task DeleteBrandAsync(string BrandId)
        {
            await _httpClient.GetAsync($"Brands/delete/{BrandId}");
        }

        public async Task<List<ResultBrandDto>> GetAllBrandsAsync()
        {
           return await _httpClient.GetFromJsonAsync<List<ResultBrandDto>>("Brands");

        }

        public async Task<UpdateBrandDto> GetByIdBrandAsync(string BrandId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateBrandDto>($"Brands/{BrandId}");
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            await _httpClient.PostAsJsonAsync<UpdateBrandDto>("Brands/update", updateBrandDto);
        }
    }
}
