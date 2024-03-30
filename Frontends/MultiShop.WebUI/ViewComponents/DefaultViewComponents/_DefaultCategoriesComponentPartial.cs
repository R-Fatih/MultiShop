using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultCategoriesComponentPartial:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _DefaultCategoriesComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
          
            var categories=await _categoryService.GetAllCategoriesAsync();
            if(categories!=null)
            {
                return View(categories);
            }
           
            return View();
        }
    }
}
