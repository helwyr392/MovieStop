using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MovieStop.Models;
using MovieStop.ViewModels;

namespace MovieStop.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        // Constructor
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: /Movies
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View();

            return View("ReadOnlyIndex");
        }

        // GET: /Movies/Details
        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            return View(movies);
        }

        // GET: /Movies/New
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        // GET: /Movies/Edit
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Id = movie.Id,
                Name = movie.Name,
                ReleasedDate = movie.ReleasedDate,
                NumberInStock = movie.NumberInStock,
                NumberAvailable = movie.NumberAvailable,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        // POST: /Movies/New
        // POST: /Movies/Edit
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleasedDate = movie.ReleasedDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreID = movie.GenreID;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.NumberAvailable = movie.NumberAvailable;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}