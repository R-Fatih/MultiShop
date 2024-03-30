using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentsDtos;
using MultiShop.WebUI.Services.CatalogServices.CommentServices;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        
        private readonly ICommentService _commentService;

		public IActionResult Index(string id)
        {
            ViewBag.CategoryId = id;

            return View();
        }
        public IActionResult ProductDetail(string id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
			return PartialView();
		}
        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto,int Rating)
        {
            string a = "";
            createCommentDto.Rating= Rating;
            createCommentDto.Status = false;
            createCommentDto.ImageUrl = "test";
            createCommentDto.CreatedDate = DateTime.UtcNow.AddHours(3);
            

            await _commentService.CreateCommentAsync(createCommentDto);
                return RedirectToAction("Index", "Default");
            
            return View();
		}
    }
}
