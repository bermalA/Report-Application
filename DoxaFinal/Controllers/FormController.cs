using Microsoft.AspNetCore.Mvc;

namespace DoxaFinal.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
