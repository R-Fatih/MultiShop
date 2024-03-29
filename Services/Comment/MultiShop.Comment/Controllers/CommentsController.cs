using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.UserComments.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(UserComment userComment)
        {
            await _context.UserComments.AddAsync(userComment);
            await _context.SaveChangesAsync();
            return Ok("Comment added");
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(UserComment userComment)
        {
            _context.UserComments.Update(userComment);
            await _context.SaveChangesAsync();
            return Ok("Comment updated");
        }
        [HttpGet("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var comment = await _context.UserComments.FindAsync(id);
            _context.UserComments.Remove(comment);
            await _context.SaveChangesAsync();
            return Ok("Comment deleted");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _context.UserComments.FindAsync(id));
        }
        [HttpGet("GetByProductId")]
        public async Task<IActionResult> GetByProductIdAsync(string productId)
        {
			return Ok(await _context.UserComments.Where(x => x.ProductId == productId&&x.Status==true).ToListAsync());
		}
    }
}
