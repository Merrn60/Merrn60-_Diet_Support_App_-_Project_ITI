 
using IV.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SelectRole(string role)
        {

            if (role == "Admin")
            {
                return RedirectToAction("LoginAdmin", "Auth");
            }
            else if (role == "User")
            {
                return RedirectToAction("LoginUser", "Auth");
            }
            else
            {
                return RedirectToAction("Signup", "Auth");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}



















