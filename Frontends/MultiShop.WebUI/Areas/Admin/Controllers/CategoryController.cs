using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/Category")]
	public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
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
            var response = await client.GetAsync("https://localhost:7148/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }

            return View();
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
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createCategoryDto);
			var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7148/api/Categories", stringContent);
			if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","Category",new {area="Admin"});
			}
			return View();
		}

		[Route("RemoveCategory/{id}")]
		public async Task<IActionResult> RemoveCategory(string id)
        {
            var client=_httpClientFactory.CreateClient();
            var response=await client.GetAsync($"https://localhost:7148/api/Categories/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Category",new {area="Admin"});
            }
            return View();
        }
        [HttpGet]
		[Route("UpdateCategory/{id}")]
		public async Task<IActionResult> UpdateCategory(string id)
        {
			var client=_httpClientFactory.CreateClient();
			var response=await client.GetAsync($"https://localhost:7148/api/Categories/{id}");
			if (response.IsSuccessStatusCode)
            {
				var jsonData=await response.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateCategory/{id}")]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            		var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateCategoryDto);
            var stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var response=await client.PostAsync("https://localhost:7148/api/Categories/Update",stringContent);
            if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","Category",new {area="Admin"});
			}
            return View();
        }
    }
}
