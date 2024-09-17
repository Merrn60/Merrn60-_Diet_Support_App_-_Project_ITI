using IV.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IV.Controllers
{
    public class VideoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VideoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Display a list of videos
        public IActionResult ListVideos()
        {
            var videos = _context.InspirationalVideos.ToList(); 
            return View(videos);  
        }
    }
}
