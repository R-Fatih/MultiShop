using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Ürün";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.title2 = "Ürün İşlemleri";


            var values = await _productService.GetProductWithCategoryAsync();

            return View(values);
        }
        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Ürün";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.title2 = "Ürün İşlemleri";
            ViewBag.Categories = await SelectListItems();
            return View();
        }
        [HttpPost]
        [Route("CreateProduct")]

        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {


            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });

            return View();
        }

        [Route("RemoveProduct/{id}")]
        public async Task<IActionResult> RemoveProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });


            return View();
        }
        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var values=await _productService.GetByIdProductAsync(id);
           
                ViewBag.Categories = await SelectListItems();

                return View(values);
            
            return View();
        }
        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            
            return View();
        }

        public async Task<List<SelectListItem>> SelectListItems()
        {
           var values= await _categoryService.GetAllCategoriesAsync();
              
                List<SelectListItem> selectListItems = new List<SelectListItem>();
                foreach (var item in values)
                {
                    selectListItems.Add(new SelectListItem { Text = item.CategoryName, Value = item.CategoryId });
                }
                return selectListItems;
            
            return null;
        }
    }
}
