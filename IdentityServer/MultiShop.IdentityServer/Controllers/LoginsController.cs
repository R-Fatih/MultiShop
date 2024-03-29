using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using MultiShop.IdentityServer.Tools;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLoginAsync(UserLoginDto userLoginDto)
        {
            var result=await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password,true, false);
            var user = _userManager.GetUserId(User);
            if (!result.Succeeded)
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }else
            {
                return Ok(JwtTokenGenerator.GenerateToken(new GetCheckAppUserViewModel
                {
                    Username = userLoginDto.Username,
                    Id = user,
                }));
            }

        }
    }
}
