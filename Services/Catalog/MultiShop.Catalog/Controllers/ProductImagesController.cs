using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var categories = await _productImageService.GetAllProductImagesAsync();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var productImage = await _productImageService.GetByIdProductImageAsync(id);
            if (productImage == null)
            {
                return NotFound();
            }
            return Ok(productImage);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("ProductImage added successfully");
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("ProductImage updated succesfully");
        }
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("ProductImage deleted succesfully");
        }
        [HttpGet("GetProductImagesByProductId")]
        public async Task<IActionResult> GetProductImagesByProductId(string productId)
        {
			var productImages = await _productImageService.GetProductImagesByProductIdAsync(productId);
			return Ok(productImages);
		}
    }
}
