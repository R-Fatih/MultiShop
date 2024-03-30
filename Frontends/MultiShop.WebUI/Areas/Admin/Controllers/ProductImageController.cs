using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/ProductImage")]
	public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [Route("Index/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Resimler";
            ViewBag.v3 = "Resimler";
            ViewBag.title2= "Resimler";
			ViewBag.prid = id;

			

            var values = await _productImageService.GetProductImagesByProductIdAsync(id);
				return View(values);
            

            return View();
        }
        [HttpGet]
        [Route("CreateProductImage/{id}")]
        public async Task<IActionResult> CreateProductImage( string id)
		{
			ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Resimler";
            ViewBag.v3 = "Resimler";
            ViewBag.title2 = "Resimler";
            TempData["id"] = id;
            return View();
        }
        [HttpPost]
		[Route("CreateProductImage/{id}")]

		public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto,string id)
        {

			id= TempData["id"].ToString();
         await   _productImageService.CreateProductImageAsync(createProductImageDto);
				return RedirectToAction("Index","ProductImage",new {area="Admin",id=id});
			
			return View();
		}

		[Route("RemoveProductImage/{id}")]
		public async Task<IActionResult> RemoveProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
			return RedirectToAction("Index", "ProductImage", new { area = "Admin", id = id });

			return View();
        }
        [HttpGet]
		[Route("UpdateProductImage/{id}")]
		public async Task<IActionResult> UpdateProductImage(string id)
        {
			
            var values = await _productImageService.GetByIdProductImageAsync(id);
				return View(values);
			
			return View();
		}
		[HttpPost]
		[Route("UpdateProductImage/{id}")]
		public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
			return RedirectToAction("Index", "ProductImage", new { area = "Admin", id = updateProductImageDto.ProductId });

			return View();
        }


    }
}
