using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/Product")]
	public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Kategori";
            ViewBag.v3 = "Kategori Listesi";
            ViewBag.title2= "Kategori İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7148/api/Products/ProductWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
		{
			ViewBag.v1 = "Ana sayfa";
			ViewBag.v2 = "Kategori";
			ViewBag.v3 = "Kategori Listesi";
			ViewBag.title2 = "Kategori İşlemleri";
            ViewBag.Categories = await SelectListItems();
			return View();
        }
        [HttpPost]
		[Route("CreateProduct")]

		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createProductDto);
			var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7148/api/Products", stringContent);
			if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","Product",new {area="Admin"});
			}
			return View();
		}

		[Route("RemoveProduct/{id}")]
		public async Task<IActionResult> RemoveProduct(string id)
        {
            var client=_httpClientFactory.CreateClient();
            var response=await client.GetAsync($"https://localhost:7148/api/Products/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Product",new {area="Admin"});
            }
            return View();
        }
        [HttpGet]
		[Route("UpdateProduct/{id}")]
		public async Task<IActionResult> UpdateProduct(string id)
        {
			var client=_httpClientFactory.CreateClient();
			var response=await client.GetAsync($"https://localhost:7148/api/Products/{id}");
			if (response.IsSuccessStatusCode)
            {
				var jsonData=await response.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
				ViewBag.Categories = await SelectListItems();

				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateProduct/{id}")]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            		var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateProductDto);
            var stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var response=await client.PostAsync("https://localhost:7148/api/Products/Update",stringContent);
            if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","Product",new {area="Admin"});
			}
            return View();
        }

        public async Task<List<SelectListItem>> SelectListItems()
        {
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7148/api/Categories");
			if (response.IsSuccessStatusCode)
            {
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
				List<SelectListItem> selectListItems = new List<SelectListItem>();
				foreach (var item in values)
                {
					selectListItems.Add(new SelectListItem { Text = item.CategoryName, Value = item.CategoryId });
				}
				return selectListItems;
			}
			return null;
		}
    }
}
