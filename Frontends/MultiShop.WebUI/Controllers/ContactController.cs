using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
			createContactDto.SendDate= DateTime.Now;
			createContactDto.IsRead = false;
				await _contactService.CreateContactAsync(createContactDto);
					return RedirectToAction("Index","Default");
				
				
			
			return View();
		}
    }
}
