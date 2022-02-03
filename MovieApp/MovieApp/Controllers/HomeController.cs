using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext _dbContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext someName)
        {
            _logger = logger;
            _dbContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _dbContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(MovieResponse movie)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(movie);
                _dbContext.SaveChanges();

                return View("Confirmation", movie);
            }
            else
            {
                ViewBag.Categories = _dbContext.Categories.ToList();
                return View(movie);
            }
        }

        public IActionResult MovieCollection()
        {
            var movies = _dbContext.Responses
                .Include(x => x.Category)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            var movie = _dbContext.Responses.Single(x => x.MovieID == movieid);

            ViewBag.Categories = _dbContext.Categories.ToList();
            return View("AddMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieResponse movie)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Responses.Update(movie);
                _dbContext.SaveChanges();

                return RedirectToAction("MovieCollection");
            }
            else
            {
                return RedirectToAction("AddMovie", movie);
            }
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = _dbContext.Responses.Single(x => x.MovieID == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(MovieResponse movie)
        {
            _dbContext.Responses.Remove(movie);
            _dbContext.SaveChanges();

            return RedirectToAction("MovieCollection");
        }

        public IActionResult Privacy()
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
