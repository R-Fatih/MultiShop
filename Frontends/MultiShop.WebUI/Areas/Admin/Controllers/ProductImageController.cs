using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/ProductImage")]
	public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductImageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Resimler";
            ViewBag.v3 = "Resimler";
            ViewBag.title2= "Resimler";
			ViewBag.prid = id;

			var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7148/api/ProductImages/GetProductImagesByProductId?productId={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);

				return View(values);
            }

            return View();
        }
        [HttpGet]
        [Route("CreateProductImage/{id}")]
        public async Task<IActionResult> CreateProductImage( string id)
		{
			ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Resimler";
            ViewBag.v3 = "Resimler";
            ViewBag.title2 = "Resimler";
            return View();
        }
        [HttpPost]
		[Route("CreateProductImage/{id}")]

		public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto,string id)
        {
			var client = _httpClientFactory.CreateClient();
            createProductImageDto.ProductId = id;
			var jsonData = JsonConvert.SerializeObject(createProductImageDto);
			var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7148/api/ProductImages", stringContent);
			if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","ProductImage",new {area="Admin",id=id});
			}
			return View();
		}

		[Route("RemoveProductImage/{id}")]
		public async Task<IActionResult> RemoveProductImage(string id)
        {
            var client=_httpClientFactory.CreateClient();
            var response=await client.GetAsync($"https://localhost:7148/api/ProductImages/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","ProductImage",new {area="Admin"});
            }
            return View();
        }
        [HttpGet]
		[Route("UpdateProductImage/{id}")]
		public async Task<IActionResult> UpdateProductImage(string id)
        {
			var client=_httpClientFactory.CreateClient();
			var response=await client.GetAsync($"https://localhost:7148/api/ProductImages/{id}");
			if (response.IsSuccessStatusCode)
            {
				var jsonData=await response.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);


				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateProductImage/{id}")]
		public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            		var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateProductImageDto);
            var stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var response=await client.PostAsync("https://localhost:7148/api/ProductImages/Update",stringContent);
            if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","ProductImage",new {area="Admin"});
			}
            return View();
        }


    }
}
