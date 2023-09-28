using DoxaFinal.Models;
using DoxaFinal.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace DoxaFinal.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserAuthenticationService _authenticationService;

        public LoginController(IUserAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            if(_authenticationService.Authenticate(user,out int UserId))
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, user.Email),
                    new Claim("OtherProperties", "Example Role")
                };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                };  
                
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index","Home");

            }

            ModelState.AddModelError(string.Empty, "Üye girişi başarısız");
            return View();
        }
    }
}
