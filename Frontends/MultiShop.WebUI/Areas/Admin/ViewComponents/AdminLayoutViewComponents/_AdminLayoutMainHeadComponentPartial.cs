using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.CommentServices;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutMainHeadComponentPartial:ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;
        public _AdminLayoutMainHeadComponentPartial(IMessageService messageService, IUserService userService, ICommentService commentService)
        {
            _messageService = messageService;
            _userService = userService;
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo(); ;
            var value=await _messageService.GetMessageCountByReseriverIdAsync(user.Id);
            ViewBag.CommentCount = await _commentService.GetTotalCommentCount();
            ViewBag.MessageCount = value;

            return View();
        }
    }
}
