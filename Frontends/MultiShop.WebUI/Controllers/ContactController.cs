using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

		public ContactController(IHttpClientFactory clientFactory)
		{
			_clientFactory = clientFactory;
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
				var client = _clientFactory.CreateClient();
				var response = await client.PostAsJsonAsync("https://localhost:7148/api/Contacts", createContactDto);
				if (response.IsSuccessStatusCode)
                {
					return RedirectToAction("Index","Default");
				}
				else
                {
				}
			
			return View();
		}
    }
}
