using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Kategori";
            ViewBag.v3 = "Kategori Listesi";
            ViewBag.title2 = "Kategori İşlemleri";


            var values = await _categoryService.GetAllCategoriesAsync();

            return View(values);
        }
        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Kategori";
            ViewBag.v3 = "Kategori Listesi";
            ViewBag.title2 = "Kategori İşlemleri";
            return View();
        }
        [HttpPost]
        [Route("CreateCategory")]

        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);

            return RedirectToAction("Index", "Category", new { area = "Admin" });

            return View();
        }


        [Route("RemoveCategory/{id}")]  
        public async Task<IActionResult> RemoveCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(string id)
        {
           
            var values = await _categoryService.GetByIdCategoryAsync(id);
                return View(values);
            
            return View();
        }
        [HttpPost]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
           await _categoryService.UpdateCategoryAsync(updateCategoryDto);
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            
            return View();
        }
    }
}
