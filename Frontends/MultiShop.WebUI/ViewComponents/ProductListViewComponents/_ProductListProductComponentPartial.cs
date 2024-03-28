using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListProductComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _ProductListProductComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            id = ViewBag.CategoryId;
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7148/api/products/ProductByCategoryId?categoryId={id}");
            if(response.IsSuccessStatusCode)
            {
                var products = await response.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();
                return View(products);
            }
            return View();
        }
    }
}
