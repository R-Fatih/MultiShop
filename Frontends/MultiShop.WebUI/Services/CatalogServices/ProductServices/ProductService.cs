using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
           await _httpClient.PostAsJsonAsync<CreateProductDto>("products",createProductDto);
            
        }

        public async Task DeleteProductAsync(string ProductId)
        {
            await _httpClient.GetAsync($"products/delete/{ProductId}");
        }


        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductDto>>("products");
        }

        public async Task<UpdateProductDto> GetByIdProductAsync(string ProductId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateProductDto>($"products/{ProductId}");
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductWithCategoryDto>>("products/ProductWithCategory");
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryByCategoryIdAsync(string CategoryId)
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductWithCategoryDto>>($"products/ProductByCategoryId?categoryId={CategoryId}");
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PostAsJsonAsync<UpdateProductDto>("products/update", updateProductDto);
        }

      

    }
}
