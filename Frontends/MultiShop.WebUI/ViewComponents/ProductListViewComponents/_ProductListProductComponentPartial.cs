using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListProductComponentPartial:ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductListProductComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            id = ViewBag.CategoryId;
            
            var products = await _productService.GetProductWithCategoryByCategoryIdAsync(id);

           
                return View(products);
            
            return View();
        }
    }
}
