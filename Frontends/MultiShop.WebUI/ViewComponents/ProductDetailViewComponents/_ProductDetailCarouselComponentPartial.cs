using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailCarouselComponentPartial : ViewComponent
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public _ProductDetailCarouselComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(string id)
        {
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync($"https://localhost:7148/api/ProductImages/GetProductImagesByProductId?productId={id}");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);

				return View(values);
			}
			return View();
        }
    }
}
