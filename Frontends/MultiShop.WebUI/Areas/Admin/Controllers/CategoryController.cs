using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Kategori";
            ViewBag.v3 = "Kategori Listesi";
            ViewBag.title2= "Kategori İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7148/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
