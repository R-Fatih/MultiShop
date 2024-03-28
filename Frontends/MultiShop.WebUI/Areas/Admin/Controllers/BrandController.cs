using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/Brand")]
	public class BrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Markalar";
            ViewBag.title2= "Markalar";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7148/api/Brands");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpGet]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand()
		{
			ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Markalar";
            ViewBag.title2 = "Markalar";

            return View();
        }
        [HttpPost]
		[Route("CreateBrand")]

		public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createBrandDto);
			var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7148/api/Brands", stringContent);
			if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","Brand",new {area="Admin"});
			}
			return View();
		}

		[Route("RemoveBrand/{id}")]
		public async Task<IActionResult> RemoveBrand(string id)
        {
            var client=_httpClientFactory.CreateClient();
            var response=await client.GetAsync($"https://localhost:7148/api/Brands/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Brand",new {area="Admin"});
            }
            return View();
        }
        [HttpGet]
		[Route("UpdateBrand/{id}")]
		public async Task<IActionResult> UpdateBrand(string id)
        {
			var client=_httpClientFactory.CreateClient();
			var response=await client.GetAsync($"https://localhost:7148/api/Brands/{id}");
			if (response.IsSuccessStatusCode)
            {
				var jsonData=await response.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);


				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateBrand/{id}")]
		public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            		var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateBrandDto);
            var stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var response=await client.PostAsync("https://localhost:7148/api/Brands/Update",stringContent);
            if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","Brand",new {area="Admin"});
			}
            return View();
        }


    }
}
