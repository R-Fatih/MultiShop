using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentsDtos;
using Newtonsoft.Json;
using System.Text;

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
        [Route("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var client = _clientFactory.CreateClient();
            var response=await client.GetAsync($"https://localhost:7153/api/Comments/Delete?id={id}");
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Comment",new {area="Admin"});
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateComment/{id}")]
        public async Task<IActionResult> UpdateComment(int id)
        {
            var client = _clientFactory.CreateClient();
            var response=await client.GetAsync($"https://localhost:7153/api/Comments/{id}");
            if(response.IsSuccessStatusCode)
            {
                var comment=await response.Content.ReadAsStringAsync();
                var jsonComment=JsonConvert.DeserializeObject<UpdateCommentDto>(comment);
                return View(jsonComment);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateComment/{id}")]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto comment)
        {
            var client = _clientFactory.CreateClient();
            var jsonComment=JsonConvert.SerializeObject(comment);
            var data=new StringContent(jsonComment,Encoding.UTF8,"application/json");
            var response=await client.PostAsync($"https://localhost:7153/api/Comments/Update",data);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Comment",new {area="Admin"});
            }
            return View();
        }
    }
}
