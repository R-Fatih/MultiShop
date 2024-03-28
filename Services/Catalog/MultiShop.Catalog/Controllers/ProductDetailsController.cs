using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var categories = await _productDetailService.GetAllProductDetailsAsync();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var productDetail = await _productDetailService.GetByIdProductDetailAsync(id);
            if (productDetail == null)
            {
                return Ok();
            }
            return Ok(productDetail);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("ProductDetail added successfully");
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("ProductDetail updated succesfully");
        }
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("ProductDetail deleted succesfully");
        }
        [HttpGet("GetProductDetailByProductId")]
        public async Task<IActionResult> GetProductDetailByProductId(string productId)
        {
			var productDetail = await _productDetailService.GetProductDetailByProductId(productId);
			if (productDetail == null)
			{
				return Ok("{}");
			}
			return Ok(productDetail);
		}
    }
}
