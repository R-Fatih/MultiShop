using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/About")]
	public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Özel teklif";
            ViewBag.v3 = "Özel teklif";
            ViewBag.title2= "Özel teklif";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7148/api/Abouts");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpGet]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout()
		{
			ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Özel teklif";
            ViewBag.v3 = "Özel teklif";
            ViewBag.title2 = "Özel teklif";

            return View();
        }
        [HttpPost]
		[Route("CreateAbout")]

		public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createAboutDto);
			var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7148/api/Abouts", stringContent);
			if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","About",new {area="Admin"});
			}
			return View();
		}

		[Route("RemoveAbout/{id}")]
		public async Task<IActionResult> RemoveAbout(string id)
        {
            var client=_httpClientFactory.CreateClient();
            var response=await client.GetAsync($"https://localhost:7148/api/Abouts/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","About",new {area="Admin"});
            }
            return View();
        }
        [HttpGet]
		[Route("UpdateAbout/{id}")]
		public async Task<IActionResult> UpdateAbout(string id)
        {
			var client=_httpClientFactory.CreateClient();
			var response=await client.GetAsync($"https://localhost:7148/api/Abouts/{id}");
			if (response.IsSuccessStatusCode)
            {
				var jsonData=await response.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);


				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateAbout/{id}")]
		public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            		var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateAboutDto);
            var stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var response=await client.PostAsync("https://localhost:7148/api/Abouts/Update",stringContent);
            if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","About",new {area="Admin"});
			}
            return View();
        }


    }
}
