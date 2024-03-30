using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;
using System.Text;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/SpecialOffer")]
	public class SpecialOfferController : Controller
	{
		private readonly ISpecialOfferService _specialOfferService;

		public SpecialOfferController(ISpecialOfferService specialOfferService)
		{
			_specialOfferService = specialOfferService;
		}
		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			ViewBag.v1 = "Ana sayfa";
			ViewBag.v2 = "Özel teklifler";
			ViewBag.v3 = "Özel teklifler";
			ViewBag.title2 = "Özel teklifler";


			var values = await _specialOfferService.GetAllSpecialOffersAsync();
			return View(values);


			return View();
		}
		[HttpGet]
		[Route("CreateSpecialOffer")]
		public async Task<IActionResult> CreateSpecialOffer()
		{
			ViewBag.v1 = "Ana sayfa";
			ViewBag.v2 = "Özel teklifler";
			ViewBag.v3 = "Özel teklifler";
			ViewBag.title2 = "Özel teklifler";

			return View();
		}
		[HttpPost]
		[Route("CreateSpecialOffer")]

		public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
		{
			await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
			return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

			return View();
		}

		[Route("RemoveSpecialOffer/{id}")]
		public async Task<IActionResult> RemoveSpecialOffer(string id)
		{
			await _specialOfferService.DeleteSpecialOfferAsync(id);

			return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

			return View();
		}
		[HttpGet]
		[Route("UpdateSpecialOffer/{id}")]
		public async Task<IActionResult> UpdateSpecialOffer(string id)
		{

			var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
			return View(values);

			return View();
		}
		[HttpPost]
		[Route("UpdateSpecialOffer/{id}")]
		public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
		{
			await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
			return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

			return View();
		}


	}
}
