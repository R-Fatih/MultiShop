using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using Newtonsoft.Json;
using System.Text;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/About")]
	public class AboutController : Controller
    {
		private readonly IAboutService _aboutService;

		public AboutController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}
		[Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.v3 = "Hakkımızda";
            ViewBag.title2= "Hakkımızda";

           
            var values=await _aboutService.GetAllAboutsAsync();
                return View(values);
            

            return View();
        }
        [HttpGet]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout()
		{
			ViewBag.v1 = "Ana sayfa";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.v3 = "Hakkımızda";
            ViewBag.title2 = "Hakkımızda";

            return View();
        }
        [HttpPost]
		[Route("CreateAbout")]

		public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
			await _aboutService.CreateAboutAsync(createAboutDto);
				return RedirectToAction("Index","About",new {area="Admin"});
			
			return View();
		}

		[Route("RemoveAbout/{id}")]
		public async Task<IActionResult> RemoveAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            
                return RedirectToAction("Index","About",new {area="Admin"});
            
            return View();
        }
        [HttpGet]
		[Route("UpdateAbout/{id}")]
		public async Task<IActionResult> UpdateAbout(string id)
        {
			
            var values=await _aboutService.GetByIdAboutAsync(id);
				return View(values);
			
			return View();
		}
		[HttpPost]
		[Route("UpdateAbout/{id}")]
		public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            	await _aboutService.UpdateAboutAsync(updateAboutDto);
				return RedirectToAction("Index","About",new {area="Admin"});
			
            return View();
        }


    }
}
