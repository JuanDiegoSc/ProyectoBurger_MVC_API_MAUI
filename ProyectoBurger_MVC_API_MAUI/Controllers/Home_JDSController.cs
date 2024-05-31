using Microsoft.AspNetCore.Mvc;
using ProyectoBurger_MVC_API_MAUI.Models;
using System.Diagnostics;

namespace ProyectoBurger_MVC_API_MAUI.Controllers
{
    public class Home_JDSController : Controller
    {
        private readonly ILogger<Home_JDSController> _logger;

        public Home_JDSController(ILogger<Home_JDSController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index_JDS()
        {
            return View();
        }

        public IActionResult Privacy_JDS()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
