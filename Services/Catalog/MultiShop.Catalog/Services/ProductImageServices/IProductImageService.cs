using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string ProductImageId);
        Task<ResultProductImageDto> GetByIdProductImageAsync(string ProductImageId);
        Task<List<ResultProductImageDto>> GetProductImagesByProductIdAsync(string ProductId);
    }
}
