using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerServices;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;
		private readonly ICargoCustomerService _cargoCustomerService;
		public UserController(IUserService userService, ICargoCustomerService cargoCustomerService)
		{
			_userService = userService;
			_cargoCustomerService = cargoCustomerService;
		}

		public async Task< IActionResult> UserList()
		{
		var values=await _userService.GetAllUsers();
			return View(values);
		}
		public async Task<IActionResult> UserAddressInfo(string id)
		{
			var values = await _cargoCustomerService.GetCargoCustomerById(id);

			return View(values);
		}

	}
}
