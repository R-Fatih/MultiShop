using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/SpecialOffer")]
	public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SpecialOfferController(IHttpClientFactory httpClientFactory)
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
            var response = await client.GetAsync("https://localhost:7148/api/SpecialOffers");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpGet]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer()
		{
			ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Özel teklif";
            ViewBag.v3 = "Özel teklif";
            ViewBag.title2 = "Özel teklif";

            return View();
        }
        [HttpPost]
		[Route("CreateSpecialOffer")]

		public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createSpecialOfferDto);
			var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7148/api/SpecialOffers", stringContent);
			if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","SpecialOffer",new {area="Admin"});
			}
			return View();
		}

		[Route("RemoveSpecialOffer/{id}")]
		public async Task<IActionResult> RemoveSpecialOffer(string id)
        {
            var client=_httpClientFactory.CreateClient();
            var response=await client.GetAsync($"https://localhost:7148/api/SpecialOffers/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","SpecialOffer",new {area="Admin"});
            }
            return View();
        }
        [HttpGet]
		[Route("UpdateSpecialOffer/{id}")]
		public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
			var client=_httpClientFactory.CreateClient();
			var response=await client.GetAsync($"https://localhost:7148/api/SpecialOffers/{id}");
			if (response.IsSuccessStatusCode)
            {
				var jsonData=await response.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);


				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateSpecialOffer/{id}")]
		public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            		var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateSpecialOfferDto);
            var stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var response=await client.PostAsync("https://localhost:7148/api/SpecialOffers/Update",stringContent);
            if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","SpecialOffer",new {area="Admin"});
			}
            return View();
        }


    }
}
