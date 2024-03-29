using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Models;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using MultiShop.WebUI.Services;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILoginService _loginService;
        private readonly IIdentityService _identityService;
        public LoginController(IHttpClientFactory clientFactory, ILoginService loginService, IIdentityService identityService)
        {
            _clientFactory = clientFactory;
            _loginService = loginService;
            _identityService = identityService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {
            var id = _loginService.GetUserId;

            var client= _clientFactory.CreateClient();
            var content=new StringContent(JsonConvert.SerializeObject(createLoginDto),Encoding.UTF8,"application/json");
            var response=await client.PostAsync("https://localhost:5001/api/logins",content);
            if(response.IsSuccessStatusCode)
            {
                var jsonData=await response.Content.ReadAsStringAsync();
                var tokenModel=System.Text.Json.JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }); 
                if(tokenModel!=null)
                {

                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();
                    if (tokenModel.Token != null)
                    {
                        claims.Add(new Claim("accessToken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var autProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), autProps);
                        return RedirectToAction("Index", "Default");
                    }
                }

            }
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignInDto signInDto)
        {
            
            await _identityService.SignIn(signInDto);
            return RedirectToAction("Index", "Default");
        }
    }
}
