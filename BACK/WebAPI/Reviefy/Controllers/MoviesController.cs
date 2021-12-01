using Microsoft.AspNetCore.Mvc;

namespace Reviefy.Controllers
{
    public class MoviesController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View("LatestMovies");
        }
        
        public IActionResult LatestMovies()
        {
            return View();
        }
        
        public IActionResult MovieDetail()
        {
            return View();
        }
    }
}