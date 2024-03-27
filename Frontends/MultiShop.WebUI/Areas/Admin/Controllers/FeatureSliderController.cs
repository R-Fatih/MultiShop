using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/FeatureSlider")]
	public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureSliderController(IHttpClientFactory httpClientFactory)
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
            var response = await client.GetAsync("https://localhost:7148/api/FeatureSliders");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpGet]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider()
		{
			ViewBag.v1 = "Ana sayfa";
			ViewBag.v2 = "Kategori";
			ViewBag.v3 = "Kategori Listesi";
			ViewBag.title2 = "Kategori İşlemleri";
            ViewBag.Categories = await SelectListItems();
			return View();
        }
        [HttpPost]
		[Route("CreateFeatureSlider")]

		public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createFeatureSliderDto);
			var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7148/api/FeatureSliders", stringContent);
			if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","FeatureSlider",new {area="Admin"});
			}
			return View();
		}

		[Route("RemoveFeatureSlider/{id}")]
		public async Task<IActionResult> RemoveFeatureSlider(string id)
        {
            var client=_httpClientFactory.CreateClient();
            var response=await client.GetAsync($"https://localhost:7148/api/FeatureSliders/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","FeatureSlider",new {area="Admin"});
            }
            return View();
        }
        [HttpGet]
		[Route("UpdateFeatureSlider/{id}")]
		public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
			var client=_httpClientFactory.CreateClient();
			var response=await client.GetAsync($"https://localhost:7148/api/FeatureSliders/{id}");
			if (response.IsSuccessStatusCode)
            {
				var jsonData=await response.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);
				ViewBag.Categories = await SelectListItems();

				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateFeatureSlider/{id}")]
		public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            		var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateFeatureSliderDto);
            var stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var response=await client.PostAsync("https://localhost:7148/api/FeatureSliders/Update",stringContent);
            if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","FeatureSlider",new {area="Admin"});
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
