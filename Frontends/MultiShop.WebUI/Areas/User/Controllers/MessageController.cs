using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;
using MultiShop.WebUI.Services.OrderServices.OrderOrderingServices;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]

    public class MessageController : Controller
    {
		private readonly IMessageService _messageService;
		private readonly IUserService _userService;

		public MessageController(IMessageService messageService, IUserService userService)
		{
			_messageService = messageService;
			_userService = userService;
		}

		public async Task< IActionResult> Inbox()
        {

			var user = await _userService.GetUserInfo();
			var values = await _messageService.GetInboxMessage(user.Id);
			return View(values);
		}
		public async Task< IActionResult> Sendbox()
		{
			var user = await _userService.GetUserInfo();
			var values = await _messageService.GetSendboxMessage(user.Id);
			return View(values);
		}
    }
}
