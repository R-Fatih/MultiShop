using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/Feature")]
	public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Feature";
            ViewBag.v3 = "Feature Listesi";
            ViewBag.title2= "Feature İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7148/api/Features");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpGet]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature()
		{
			ViewBag.v1 = "Ana sayfa";
			ViewBag.v2 = "Feature";
			ViewBag.v3 = "Feature Listesi";
			ViewBag.title2 = "Feature İşlemleri";
            ViewBag.Categories = await SelectListItems();
			return View();
        }
        [HttpPost]
		[Route("CreateFeature")]

		public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createFeatureDto);
			var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7148/api/Features", stringContent);
			if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","Feature",new {area="Admin"});
			}
			return View();
		}

		[Route("RemoveFeature/{id}")]
		public async Task<IActionResult> RemoveFeature(string id)
        {
            var client=_httpClientFactory.CreateClient();
            var response=await client.GetAsync($"https://localhost:7148/api/Features/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Feature",new {area="Admin"});
            }
            return View();
        }
        [HttpGet]
		[Route("UpdateFeature/{id}")]
		public async Task<IActionResult> UpdateFeature(string id)
        {
			var client=_httpClientFactory.CreateClient();
			var response=await client.GetAsync($"https://localhost:7148/api/Features/{id}");
			if (response.IsSuccessStatusCode)
            {
				var jsonData=await response.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
				ViewBag.Categories = await SelectListItems();

				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateFeature/{id}")]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            		var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateFeatureDto);
            var stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var response=await client.PostAsync("https://localhost:7148/api/Features/Update",stringContent);
            if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","Feature",new {area="Admin"});
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
