using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultCarouselComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _DefaultCarouselComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_clientFactory.CreateClient();
            var response=await client.GetAsync("https://localhost:7148/api/FeatureSliders");
            if (response.IsSuccessStatusCode)
            {
                var jsonData=await response.Content.ReadAsStringAsync();
                var sliders=JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
                return View(sliders);
            }
            return View();
        }
    }
}
