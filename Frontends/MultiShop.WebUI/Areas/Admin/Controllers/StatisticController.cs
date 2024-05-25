using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.CommentServices;
using MultiShop.WebUI.Services.DiscountServices;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class StatisticController : Controller
	{
		private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly  IUserService _userService;
		private readonly ICommentService _commentService;
		private readonly IDiscountService _discountService;
		private readonly IMessageService _messageService;
        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserService userService, ICommentService commentService, IDiscountService discountService, IMessageService messageService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userService = userService;
            _commentService = commentService;
            _discountService = discountService;
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
		{
			var categoryCount =await _catalogStatisticService.GetCategoryCount();
			var brandCount = await _catalogStatisticService.GetBrandCount();
			var productCount = await _catalogStatisticService.GetProductCount();
		//	var productAvgPrice = await _catalogStatisticService.GetProductAvgPrice();
			var maxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
			var minPriceProductName = await _catalogStatisticService.GetMinPriceProductName();
			var userCount = await _userService.GetUserCount();
			var totalCommentCount = await _commentService.GetTotalCommentCount();
			var activeCommentCount = await _commentService.GetActiveCommentCountAsync();
			var passiveCommentCount = await _commentService.GetPassiveCommentCount();
			var discountCouponCount = await _discountService.GetDiscountCouponCount();
			var totalMessageCount = await _messageService.GetMessageCountAsync();

			ViewBag.CategoryCount = categoryCount;
			ViewBag.BrandCount = brandCount;
			ViewBag.ProductCount = productCount;
			//ViewBag.ProductAvgPrice = productAvgPrice;
			ViewBag.MaxPriceProductName = maxPriceProductName;
			ViewBag.MinPriceProductName = minPriceProductName;
			ViewBag.UserCount = userCount;
			ViewBag.TotalCommentCount = totalCommentCount;
			ViewBag.ActiveCommentCount = activeCommentCount;
			ViewBag.PassiveCommentCount = passiveCommentCount;
			ViewBag.DiscountCouponCount = discountCouponCount;
			ViewBag.TotalMessageCount = totalMessageCount;
			return View();
		}
	}
}
