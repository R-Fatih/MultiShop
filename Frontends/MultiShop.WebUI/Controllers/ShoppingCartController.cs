﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
		private readonly IProductService _productService;
		private readonly IBasketService _basketService;

		public ShoppingCartController(IProductService productService, IBasketService basketService)
		{
			_productService = productService;
			_basketService = basketService;
		}

		public async Task<IActionResult> Index(string code,int discrate,decimal newprice)
		{
			ViewBag.code=code;
			ViewBag.discrate=discrate;
			ViewBag.newprice=newprice;
			return View();
		}
		public async Task<IActionResult> AddBasketItem(string id)
		{

			var values = await _productService.GetByIdProductAsync(id);
			var items = new BasketItemDto
			{
				ProductId = values.ProductId,
				ProductName = values.ProductName,
				Price = values.ProductPrice
				,
				Quantity = 1,
				ProductImageUrl=values.ProductImageUrl
			};
			await _basketService.AddBasketItem(items);
			return RedirectToAction("Index", "ShoppingCart");
		}
		public async Task<IActionResult> RemoveBasketItem(string id)
		{
			await _basketService.RemoveBasketItem(id);
			return RedirectToAction("Index");
		}
	}
}
