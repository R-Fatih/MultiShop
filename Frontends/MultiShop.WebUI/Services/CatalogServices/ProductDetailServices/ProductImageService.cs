using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService: IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

		public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
		{
			await _httpClient.PostAsJsonAsync<CreateProductDetailDto>("ProductDetails", createProductDetailDto);

		}

		public async Task DeleteProductDetailAsync(string ProductDetailId)
		{
			await _httpClient.GetAsync($"ProductDetails/delete/{ProductDetailId}");
		}

		public async Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync()
		{
			return await _httpClient.GetFromJsonAsync<List<ResultProductDetailDto>>("ProductDetails");

		}

		public async Task<UpdateProductDetailDto> GetByIdProductDetailAsync(string ProductDetailId)
		{
			return await _httpClient.GetFromJsonAsync<UpdateProductDetailDto>($"ProductDetails/{ProductDetailId}");
		}

		public async Task<ResultProductDetailDto> GetProductDetailByProductId(string ProductId)
		{
			return await _httpClient.GetFromJsonAsync<ResultProductDetailDto>($"ProductDetails/GetProductDetailByProductId?productId={ProductId}");
		}

		public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
		{
			await _httpClient.PostAsJsonAsync<UpdateProductDetailDto>("ProductDetails/update", updateProductDetailDto);
		}

	}
}
