using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CommentsDtos;
using Newtonsoft.Json;
using System.Text;
using MultiShop.WebUI.Services.CatalogServices.CommentServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Comment")]
	public class CommentController : Controller
	{
		private readonly ICommentService _commentService;

		public CommentController(ICommentService CommentService)
		{
			_commentService = CommentService;
		}
		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			ViewBag.v1 = "Ana sayfa";
			ViewBag.v2 = "Yorumlar";
			ViewBag.v3 = "Yorumlar";
			ViewBag.title2 = "Yorumlar";


			var values = await _commentService.GetAllCommentsAsync();
			return View(values);


			return View();
		}
		[HttpGet]
		[Route("CreateComment")]
		public async Task<IActionResult> CreateComment()
		{
			ViewBag.v1 = "Ana sayfa";
			ViewBag.v2 = "Yorumlar";
			ViewBag.v3 = "Yorumlar";
			ViewBag.title2 = "Yorumlar";

			return View();
		}
		[HttpPost]
		[Route("CreateComment")]

		public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
		{
			await _commentService.CreateCommentAsync(createCommentDto);
			return RedirectToAction("Index", "Comment", new { area = "Admin" });

			return View();
		}

		[Route("RemoveComment/{id}")]
		public async Task<IActionResult> RemoveComment(string id)
		{
			await _commentService.DeleteCommentAsync(id);

			return RedirectToAction("Index", "Comment", new { area = "Admin" });

			return View();
		}
		[HttpGet]
		[Route("UpdateComment/{id}")]
		public async Task<IActionResult> UpdateComment(string id)
		{

			var values = await _commentService.GetByIdCommentAsync(id);
			return View(values);

			return View();
		}
		[HttpPost]
		[Route("UpdateComment/{id}")]
		public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
		{
			await _commentService.UpdateCommentAsync(updateCommentDto);
			return RedirectToAction("Index", "Comment", new { area = "Admin" });

			return View();
		}


	}
}
