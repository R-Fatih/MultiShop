using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultSpecialOfferComponentPartial:ViewComponent
    {
        
        private readonly ISpecialOfferService _specialOfferService;

		public _DefaultSpecialOfferComponentPartial(ISpecialOfferService specialOfferService)
		{
			_specialOfferService = specialOfferService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var values=await _specialOfferService.GetAllSpecialOffersAsync();
                return View(values);
            
            return View();
        }
    }
}
