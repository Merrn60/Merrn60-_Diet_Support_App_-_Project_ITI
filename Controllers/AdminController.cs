using IV.Models;
using Microsoft.AspNetCore.Mvc;

namespace IV.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

         
        public IActionResult AdminDashboard()
        {
            return View();
        }

       
        [HttpGet]
        public IActionResult AddQuote()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddVideo(string videoTitle, string videoUrl, string videoCategory)
        {
            var video = new InspirationalVideo
            {
                Title = videoTitle,
                URL = videoUrl,
                Category = videoCategory,
                UserID = 1  
            };

            _context.InspirationalVideos.Add(video);

            try
            {
                _context.SaveChanges();
                return RedirectToAction("AdminDashboard");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
            }

            return View("AdminDashboard");
        }











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

            return View(model);
        }

        [HttpPost]
public IActionResult AddQuote(string quoteText, string author, string category)
{
    if (!string.IsNullOrEmpty(quoteText))
    {
        var quote = new MotivationalQuote
        {
            Content = quoteText,
            Author = !string.IsNullOrEmpty(author) ? author : "Unknown",  
            Category = !string.IsNullOrEmpty(category) ? category : "General"  
        };
        _context.MotivationalQuotes.Add(quote);
        _context.SaveChanges();

        ViewBag.Message = "Quote added successfully!";
    }
    return RedirectToAction("AdminDashboard");
}


    }
}
