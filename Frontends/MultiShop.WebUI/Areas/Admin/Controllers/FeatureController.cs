using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;
using System.Text;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Feature")]
	public class FeatureController : Controller
	{
		private readonly IFeatureService _featureService;

		public FeatureController(IFeatureService featureService)
		{
			_featureService = featureService;
		}
		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			ViewBag.v1 = "Ana sayfa";
			ViewBag.v2 = "Features";
			ViewBag.v3 = "Features";
			ViewBag.title2 = "Features";


			var values = await _featureService.GetAllFeaturesAsync();
			return View(values);


			return View();
		}
		[HttpGet]
		[Route("CreateFeature")]
		public async Task<IActionResult> CreateFeature()
		{
			ViewBag.v1 = "Ana sayfa";
			ViewBag.v2 = "Features";
			ViewBag.v3 = "Features";
			ViewBag.title2 = "Features";

			return View();
		}
		[HttpPost]
		[Route("CreateFeature")]

		public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
		{
			await _featureService.CreateFeatureAsync(createFeatureDto);
			return RedirectToAction("Index", "Feature", new { area = "Admin" });

			return View();
		}

		[Route("RemoveFeature/{id}")]
		public async Task<IActionResult> RemoveFeature(string id)
		{
			await _featureService.DeleteFeatureAsync(id);

			return RedirectToAction("Index", "Feature", new { area = "Admin" });

			return View();
		}
		[HttpGet]
		[Route("UpdateFeature/{id}")]
		public async Task<IActionResult> UpdateFeature(string id)
		{

			var values = await _featureService.GetByIdFeatureAsync(id);
			return View(values);

			return View();
		}
		[HttpPost]
		[Route("UpdateFeature/{id}")]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
		{
			await _featureService.UpdateFeatureAsync(updateFeatureDto);
			return RedirectToAction("Index", "Feature", new { area = "Admin" });

			return View();
		}


	}
}
