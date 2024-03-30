using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentsDtos;
using MultiShop.WebUI.Services.CatalogServices.CommentServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial:ViewComponent
    {

        private readonly ICommentService _commentService;

		public _ProductDetailReviewComponentPartial(ICommentService commentService)
		{
			_commentService = commentService;
		}

		public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            id = ViewBag.ProductId;
            TempData["ProductId"]=id;
            
            var jsonComments = await _commentService.GetCommentsByProductIdAsync(id);
                return View(jsonComments);
            
            return View();
        }
    }
}
