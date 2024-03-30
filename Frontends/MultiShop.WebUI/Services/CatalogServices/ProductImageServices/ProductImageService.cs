using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService: IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductImageDto>("productimages", createProductImageDto);

        }

        public async Task DeleteProductImageAsync(string ProductImageId)
        {
            await _httpClient.GetAsync($"productimages/delete/{ProductImageId}");
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductImageDto>>("productimages");

        }

        public async Task<UpdateProductImageDto> GetByIdProductImageAsync(string ProductImageId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateProductImageDto>($"productimages/{ProductImageId}");
        }

        public async Task<List<ResultProductImageDto>> GetProductImagesByProductIdAsync(string ProductId)
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductImageDto>>($"productimages/GetProductImagesByProductId?productId={ProductId}");
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _httpClient.PostAsJsonAsync<UpdateProductImageDto>("productimages/update", updateProductImageDto);
        }

        
    }
}
