using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/ProductDetail")]
	public class ProductDetailController : Controller
    {
        private readonly IProductDetailService _productDetailService;

		public ProductDetailController(IProductDetailService productDetailService)
		{
			_productDetailService = productDetailService;
		}

		[Route("Index/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Detaylar";
            ViewBag.v3 = "Detaylar";
            ViewBag.title2= "Detaylar";
			ViewBag.prid = id;

			

           var values=await _productDetailService.GetProductDetailByProductId(id);
			return View(values);
            

            return View();
        }
        [HttpGet]
        [Route("CreateProductDetail/{id}")]
        public async Task<IActionResult> CreateProductDetail( string id)
		{
			ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Detaylar";
            ViewBag.v3 = "Detaylar";
            ViewBag.title2 = "Detaylar";
            return View();
        }
        [HttpPost]
		[Route("CreateProductDetail/{id}")]

		public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto,string id)
        {
			
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
				return RedirectToAction("Index","ProductDetail",new {area="Admin",id=id});
			
			return View();
		}

		[Route("RemoveProductDetail/{id}")]
		public async Task<IActionResult> RemoveProductDetail(string id)
        {
           await _productDetailService.DeleteProductDetailAsync(id);
                return RedirectToAction("Index","ProductDetail",new {area="Admin"});
            
            return View();
        }
        [HttpGet]
		[Route("UpdateProductDetail/{id}")]
		public async Task<IActionResult> UpdateProductDetail(string id)
        {
			var values=await _productDetailService.GetByIdProductDetailAsync(id);
				return View(values);
			
			return View();
		}
		[HttpPost]
		[Route("UpdateProductDetail/{id}")]
		public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            		await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
				return RedirectToAction("Index","ProductDetail",new {area="Admin"});
			
            return View();
        }


    }
}
