
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
	public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string ProductDetailId);
        Task<UpdateProductDetailDto> GetByIdProductDetailAsync(string ProductDetailId);
        Task<ResultProductDetailDto> GetProductDetailByProductId(string ProductId);
    }
}
