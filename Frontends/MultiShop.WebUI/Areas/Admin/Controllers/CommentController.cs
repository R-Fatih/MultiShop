using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentsDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public CommentController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response=await client.GetAsync("https://localhost:7153/api/Comments");
            if(response.IsSuccessStatusCode)
            {
                var comments=await response.Content.ReadAsStringAsync();
                var jsonComments=JsonConvert.DeserializeObject<List<ResultCommentDto>>(comments);
                return View(jsonComments);
            }

            return View();
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _clientFactory.CreateClient();
            var response=await client.GetAsync($"https://localhost:7153/api/Comments/Delete?id={id}");
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Comment",new {area="Admin"});
            }
            return View();
        }
    }
}
