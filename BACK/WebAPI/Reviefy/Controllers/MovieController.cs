using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Reviefy.Models;

namespace Reviefy.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDataConnection _connection;
        private List<Movie> GetMovies() =>
            _connection.Movie.OrderByDescending(x => x.ReleaseDate).ToList();
        public MovieController(AppDataConnection connection) => _connection = connection;

        // GET
        public IActionResult LatestMovies(Guid id)
        {
            if (id == Guid.Empty)
                return View(GetMovies());

            var movie = _connection.Movie.FirstOrDefault(x => x.MovieId == id);
            var moviePhoto = _connection.MoviePhoto.FirstOrDefault(x => x.MovieId == id);
            var reviews = _connection.Review
                                    .Where(x => x.MovieId == id)
                                    .OrderBy(x => x.ReviewDate).ToList();

            var user = _connection.User;

            ViewBag.Movie = movie;
            ViewBag.MoviePhoto = moviePhoto;
            ViewBag.Reviews = reviews;
            ViewBag.User = user;
            return movie == null ? RedirectToAction("PageNotFound", "Home") : View("MovieDetail");
        }

        public IActionResult TopRatedMovies() => View();
    }
}