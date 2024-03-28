﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _NavbarUILayoutComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7148/api/categories");
            if(response.IsSuccessStatusCode)
            {
                var categories = await response.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
                return View(categories);
            }
            return View();
        }
    }
}
