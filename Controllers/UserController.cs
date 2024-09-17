using IV.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IV.Controllers
{
    public class UserController : Controller
    {


        public IActionResult UserDashboard()
        {
            ViewData["Title"] = "User Dashboard";
            return View();
        }

        public IActionResult InspirationalVideos()
        {
            var videos = _context.InspirationalVideos.ToList();
            return View(videos);
        }

        private readonly ApplicationDbContext _context;
         
        public UserController(ApplicationDbContext context)
        {


             
 
 
    




    _context = context;
        }

        
        public IActionResult ShowRandomQuote()
        {
            var quote = _context.MotivationalQuotes.OrderBy(q => Guid.NewGuid()).FirstOrDefault();
            return View("ShowRandomQuote", quote);
        }

         
        public IActionResult ShowRandomVideo()
        {
            var randomVideo = _context.InspirationalVideos
                                       .OrderBy(v => Guid.NewGuid())
                                       .FirstOrDefault();

            return View(randomVideo);
        }

       
        [HttpGet]
        public IActionResult CalorieCalculator()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleFavorite(int quoteId)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var quote = _context.MotivationalQuotes.FirstOrDefault(q => q.ID == quoteId);

            if (quote != null)
            {
                // Toggle favorite status
                quote.IsFavorite = !quote.IsFavorite;
                _context.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }
         
        [HttpPost]
        public IActionResult CalorieCalculator(CalorieCalculation model)
        {
            if (ModelState.IsValid)
            {
                 
                return View("~/Views/CalorieCalculator/CalorieCalculator.cshtml");

            }
            return View(model);
        }
    }
}
