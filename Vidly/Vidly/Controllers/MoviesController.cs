using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _DBContext;

        public MoviesController ()
        {
            _DBContext = new ApplicationDbContext();
        }

        public ActionResult Details(int id)
        {
            var movie = _DBContext.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            return View(movie);
        }

        protected override void Dispose(bool disposing)
        {
            _DBContext.Dispose();
        }


        public ActionResult Edit(int id)
        {
            var movie = _DBContext.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null) return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _DBContext.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var genres = _DBContext.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1" },
                new Customer {Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _DBContext.Genres.ToList()
                };
                return View("MoviesFormForm", viewModel);
            }

            // New movie
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _DBContext.Movies.Add(movie);
            }
            // Existing movie
            else
            {
                var existingMovie = _DBContext.Movies.Single(m => m.Id == movie.Id);

                existingMovie.Name = movie.Name;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.GenreId = movie.GenreId;
                existingMovie.NumberInStock = movie.NumberInStock;
            }

            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}