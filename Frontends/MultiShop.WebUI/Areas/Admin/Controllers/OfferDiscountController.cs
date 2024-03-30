using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;
using System.Text;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/OfferDiscount")]
	public class OfferDiscountController : Controller
	{
		private readonly IOfferDiscountService _offerDiscountService;

		public OfferDiscountController(IOfferDiscountService offerDiscountService)
		{
			_offerDiscountService = offerDiscountService;
		}
		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			ViewBag.v1 = "Ana sayfa";
			ViewBag.v2 = "Offer discounts";
			ViewBag.v3 = "Offer discounts";
			ViewBag.title2 = "Offer discounts";


			var values = await _offerDiscountService.GetAllOfferDiscountsAsync();
			return View(values);


			return View();
		}
		[HttpGet]
		[Route("CreateOfferDiscount")]
		public async Task<IActionResult> CreateOfferDiscount()
		{
			ViewBag.v1 = "Ana sayfa";
			ViewBag.v2 = "Offer discounts";
			ViewBag.v3 = "Offer discounts";
			ViewBag.title2 = "Offer discounts";

			return View();
		}
		[HttpPost]
		[Route("CreateOfferDiscount")]

		public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
		{
			await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
			return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });

			return View();
		}

		[Route("RemoveOfferDiscount/{id}")]
		public async Task<IActionResult> RemoveOfferDiscount(string id)
		{
			await _offerDiscountService.DeleteOfferDiscountAsync(id);

			return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });

			return View();
		}
		[HttpGet]
		[Route("UpdateOfferDiscount/{id}")]
		public async Task<IActionResult> UpdateOfferDiscount(string id)
		{

			var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
			return View(values);

			return View();
		}
		[HttpPost]
		[Route("UpdateOfferDiscount/{id}")]
		public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
		{
			await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
			return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });

			return View();
		}


	}
}
