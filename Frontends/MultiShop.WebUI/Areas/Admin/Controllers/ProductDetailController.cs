using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/ProductDetail")]
	public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Detaylar";
            ViewBag.v3 = "Detaylar";
            ViewBag.title2= "Detaylar";
			ViewBag.prid = id;

			var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7148/api/ProductDetails/GetProductDetailByProductId?productId={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<ResultProductDetailDto>(jsonData);

				return View(values);
            }

            return View();
        }
        [HttpGet]
        [Route("CreateProductDetail/{id}")]
        public async Task<IActionResult> CreateProductDetail( string id)
		{
			ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Detaylar";
            ViewBag.v3 = "Detaylar";
            ViewBag.title2 = "Detaylar";
            return View();
        }
        [HttpPost]
		[Route("CreateProductDetail/{id}")]

		public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto,string id)
        {
			var client = _httpClientFactory.CreateClient();
            createProductDetailDto.ProductId = id;
			var jsonData = JsonConvert.SerializeObject(createProductDetailDto);
			var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7148/api/ProductDetails", stringContent);
			if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","ProductDetail",new {area="Admin",id=id});
			}
			return View();
		}

		[Route("RemoveProductDetail/{id}")]
		public async Task<IActionResult> RemoveProductDetail(string id)
        {
            var client=_httpClientFactory.CreateClient();
            var response=await client.GetAsync($"https://localhost:7148/api/ProductDetails/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","ProductDetail",new {area="Admin"});
            }
            return View();
        }
        [HttpGet]
		[Route("UpdateProductDetail/{id}")]
		public async Task<IActionResult> UpdateProductDetail(string id)
        {
			var client=_httpClientFactory.CreateClient();
			var response=await client.GetAsync($"https://localhost:7148/api/ProductDetails/{id}");
			if (response.IsSuccessStatusCode)
            {
				var jsonData=await response.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);


				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateProductDetail/{id}")]
		public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            		var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateProductDetailDto);
            var stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var response=await client.PostAsync("https://localhost:7148/api/ProductDetails/Update",stringContent);
            if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","ProductDetail",new {area="Admin"});
			}
            return View();
        }


    }
}
