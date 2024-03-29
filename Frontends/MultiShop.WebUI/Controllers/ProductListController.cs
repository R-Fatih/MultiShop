using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentsDtos;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

		public ProductListController(IHttpClientFactory clientFactory)
		{
			_clientFactory = clientFactory;
		}

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
            var client = _clientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7153/api/Comments", createCommentDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
		}
    }
}
