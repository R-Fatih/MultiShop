using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/OfferDiscount")]
	public class OfferDiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OfferDiscountController(IHttpClientFactory httpClientFactory)
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
            var response = await client.GetAsync("https://localhost:7148/api/OfferDiscounts");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpGet]
        [Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount()
		{
			ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Özel teklif";
            ViewBag.v3 = "Özel teklif";
            ViewBag.title2 = "Özel teklif";

            return View();
        }
        [HttpPost]
		[Route("CreateOfferDiscount")]

		public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createOfferDiscountDto);
			var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7148/api/OfferDiscounts", stringContent);
			if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","OfferDiscount",new {area="Admin"});
			}
			return View();
		}

		[Route("RemoveOfferDiscount/{id}")]
		public async Task<IActionResult> RemoveOfferDiscount(string id)
        {
            var client=_httpClientFactory.CreateClient();
            var response=await client.GetAsync($"https://localhost:7148/api/OfferDiscounts/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","OfferDiscount",new {area="Admin"});
            }
            return View();
        }
        [HttpGet]
		[Route("UpdateOfferDiscount/{id}")]
		public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
			var client=_httpClientFactory.CreateClient();
			var response=await client.GetAsync($"https://localhost:7148/api/OfferDiscounts/{id}");
			if (response.IsSuccessStatusCode)
            {
				var jsonData=await response.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<UpdateOfferDiscountDto>(jsonData);


				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateOfferDiscount/{id}")]
		public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            		var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateOfferDiscountDto);
            var stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var response=await client.PostAsync("https://localhost:7148/api/OfferDiscounts/Update",stringContent);
            if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","OfferDiscount",new {area="Admin"});
			}
            return View();
        }


    }
}
