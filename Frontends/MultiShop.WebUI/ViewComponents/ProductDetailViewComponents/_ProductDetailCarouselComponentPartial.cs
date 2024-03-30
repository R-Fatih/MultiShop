using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailCarouselComponentPartial : ViewComponent
    {
        private readonly IProductImageService _productImageService;

        public _ProductDetailCarouselComponentPartial(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values=await _productImageService.GetProductImagesByProductIdAsync(id);
			
				return View(values);
			
			return View();
        }
    }
}
