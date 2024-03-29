using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentsDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _ProductDetailReviewComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            id = ViewBag.ProductId;
            TempData["ProductId"]=id;
            var client = _clientFactory.CreateClient();
            var response=await client.GetAsync("https://localhost:7153/api/Comments/GetByProductId?productId="+id);
            if(response.IsSuccessStatusCode)
            {
                var comments=await response.Content.ReadAsStringAsync();
                var jsonComments=JsonConvert.DeserializeObject<List<ResultCommentDto>>(comments);
                return View(jsonComments);
            }
            return View();
        }
    }
}
