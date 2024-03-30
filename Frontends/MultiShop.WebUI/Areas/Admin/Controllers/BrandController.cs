using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;
using System.Text;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Brand")]
	public class BrandController : Controller
	{
		private readonly IBrandService _brandService;

		public BrandController(IBrandService brandService)
		{
			_brandService = brandService;
		}
		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			ViewBag.v1 = "Ana sayfa";
			ViewBag.v2 = "Offer discounts";
			ViewBag.v3 = "Offer discounts";
			ViewBag.title2 = "Offer discounts";


			var values = await _brandService.GetAllBrandsAsync();
			return View(values);


			return View();
		}
		[HttpGet]
		[Route("CreateBrand")]
		public async Task<IActionResult> CreateBrand()
		{
			ViewBag.v1 = "Ana sayfa";
			ViewBag.v2 = "Offer discounts";
			ViewBag.v3 = "Offer discounts";
			ViewBag.title2 = "Offer discounts";

			return View();
		}
		[HttpPost]
		[Route("CreateBrand")]

		public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
		{
			await _brandService.CreateBrandAsync(createBrandDto);
			return RedirectToAction("Index", "Brand", new { area = "Admin" });

			return View();
		}

		[Route("RemoveBrand/{id}")]
		public async Task<IActionResult> RemoveBrand(string id)
		{
			await _brandService.DeleteBrandAsync(id);

			return RedirectToAction("Index", "Brand", new { area = "Admin" });

			return View();
		}
		[HttpGet]
		[Route("UpdateBrand/{id}")]
		public async Task<IActionResult> UpdateBrand(string id)
		{

			var values = await _brandService.GetByIdBrandAsync(id);
			return View(values);

			return View();
		}
		[HttpPost]
		[Route("UpdateBrand/{id}")]
		public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
		{
			await _brandService.UpdateBrandAsync(updateBrandDto);
			return RedirectToAction("Index", "Brand", new { area = "Admin" });

			return View();
		}


	}
}
