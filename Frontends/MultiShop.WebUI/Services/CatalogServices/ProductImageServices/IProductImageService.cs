using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string ProductImageId);
        Task<UpdateProductImageDto> GetByIdProductImageAsync(string ProductImageId);
        Task<List<ResultProductImageDto>> GetProductImagesByProductIdAsync(string ProductId);
    }
}
