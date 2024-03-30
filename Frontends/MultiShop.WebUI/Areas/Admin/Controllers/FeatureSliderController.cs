using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;
using System.Text;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/FeatureSlider")]
	public class FeatureSliderController : Controller
	{
		private readonly IFeatureSliderService _featureSliderService;

		public FeatureSliderController(IFeatureSliderService featureSliderService)
		{
			_featureSliderService = featureSliderService;
		}
		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			ViewBag.v1 = "Ana sayfa";
			ViewBag.v2 = "Feature slider";
			ViewBag.v3 = "Feature slider";
			ViewBag.title2 = "Feature slider";


			var values = await _featureSliderService.GetAllFeatureSlidersAsync();
			return View(values);


			return View();
		}
		[HttpGet]
		[Route("CreateFeatureSlider")]
		public async Task<IActionResult> CreateFeatureSlider()
		{
			ViewBag.v1 = "Ana sayfa";
			ViewBag.v2 = "Feature slider";
			ViewBag.v3 = "Feature slider";
			ViewBag.title2 = "Feature slider";

			return View();
		}
		[HttpPost]
		[Route("CreateFeatureSlider")]

		public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
		{
			await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
			return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });

			return View();
		}

		[Route("RemoveFeatureSlider/{id}")]
		public async Task<IActionResult> RemoveFeatureSlider(string id)
		{
			await _featureSliderService.DeleteFeatureSliderAsync(id);

			return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });

			return View();
		}
		[HttpGet]
		[Route("UpdateFeatureSlider/{id}")]
		public async Task<IActionResult> UpdateFeatureSlider(string id)
		{

			var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);
			return View(values);

			return View();
		}
		[HttpPost]
		[Route("UpdateFeatureSlider/{id}")]
		public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
		{
			await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
			return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });

			return View();
		}


	}
}
