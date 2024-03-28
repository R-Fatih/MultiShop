using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultBrandsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultBrandsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
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
    }
}
