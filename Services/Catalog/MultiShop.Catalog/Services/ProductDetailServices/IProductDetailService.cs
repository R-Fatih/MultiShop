using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string ProductDetailId);
        Task<ResultProductDetailDto> GetByIdProductDetailAsync(string ProductDetailId);
        Task<ResultProductDetailDto> GetProductDetailByProductId(string ProductId);
    }
}
