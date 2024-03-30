using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultFeatureComponentPartial:ViewComponent
    {

        private readonly IFeatureService _featureService;

		public _DefaultFeatureComponentPartial(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _featureService.GetAllFeaturesAsync();
                return View(values);
            
            return View();
        }
    }
}
