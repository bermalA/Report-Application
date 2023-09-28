using DoxaFinal.Models;
using DoxaFinal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoxaFinal.Controllers
{
    [Authorize]
    public class SigninController : Controller
    {
        private readonly IUserStorage _userStorage;

        public SigninController(IUserStorage userStorage)
        {
            _userStorage = userStorage;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
          string validationError = _userStorage.SaveUser(user);

            if (validationError != null)
            {
                ModelState.AddModelError(string.Empty, validationError);
                return View(user);
            }

            return RedirectToAction("Index", "Login");
        }
    }
}
