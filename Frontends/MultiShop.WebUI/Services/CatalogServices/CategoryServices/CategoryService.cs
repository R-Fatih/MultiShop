using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
           await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories",createCategoryDto);
            
        }

        public async Task DeleteCategoryAsync(string categoryId)
        {
            await _httpClient.GetAsync($"categories/delete/{categoryId}");
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
           return await _httpClient.GetFromJsonAsync<List<ResultCategoryDto>>("categories");

        }

        public async Task<UpdateCategoryDto> GetByIdCategoryAsync(string categoryId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateCategoryDto>($"categories/{categoryId}");
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _httpClient.PostAsJsonAsync<UpdateCategoryDto>("categories/update", updateCategoryDto);
        }
    }
}
