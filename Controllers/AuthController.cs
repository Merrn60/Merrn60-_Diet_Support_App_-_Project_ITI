 
using IV.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IV.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Login Page for Users
        [HttpGet]
        public IActionResult LoginUser()
        {
            ViewData["Title"] = "User Login";
            return View();
        }

        // Login Page for Admin
        [HttpGet]
        public IActionResult LoginAdmin()
        {
            ViewData["Title"] = "Admin Login";
            return View("~/Views/Auth/LoginAdmin.cshtml");
        }

        // Sign Up Page for New Users
        [HttpGet]
        public IActionResult Signup()
        {
            ViewData["Title"] = "Sign Up";
            return View();
        }

        // Post Login for Users
        [HttpPost]
        public IActionResult LoginUser(User model)
        {
            if (ModelState.IsValid)
            {
                 
                var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                   
                    return RedirectToAction("UserDashboard", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            return View(model);
        }



        // Post Login for Admin
        [HttpPost]
        public IActionResult LoginAdmin(Admin model)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("Model is valid");
                var admin = _context.Admins.FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);

                if (admin != null)
                {
                    Console.WriteLine("Admin found, redirecting to AdminDashboard");
                    return RedirectToAction("AdminDashboard", "Admin");
                }
                else
                {
                    Console.WriteLine("Invalid login attempt");
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }
            else
            {
                Console.WriteLine("Model is not valid");
            }

            return View("~/Views/Auth/LoginAdmin.cshtml", model);
        }


        [HttpPost]
        public IActionResult Signup(User model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Email already exists.");
                    return View(model);
                }

                try
                {
                    var user = new User
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Age = model.Age,
                        Weight = model.Weight,
                        Height = model.Height,
                        Gender = model.Gender,
                        Password = model.Password,
                        MotivationalQuotes = new List<MotivationalQuote>(),
                        CalorieCalculations = new List<CalorieCalculation>(),
                        InspirationalVideos = new List<InspirationalVideo>()
                    };

                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return RedirectToAction("LoginUser");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Model is not valid");
            }

            return View(model);
        }

    }
}