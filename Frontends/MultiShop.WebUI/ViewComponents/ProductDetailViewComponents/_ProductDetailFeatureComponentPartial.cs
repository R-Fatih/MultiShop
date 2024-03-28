using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailFeatureComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

		public _ProductDetailFeatureComponentPartial(IHttpClientFactory clientFactory)
		{
			_clientFactory = clientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            
            id=ViewBag.ProductId;   

            var client= _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7148/api/Products/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData= await response.Content.ReadAsStringAsync();
                var product=JsonConvert.DeserializeObject<ResultProductDto>(jsonData);
				return View(product);
			}
			
            return View();
        }
    }
}
