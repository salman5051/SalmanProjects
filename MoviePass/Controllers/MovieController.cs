using MoviePass.Models;
using MoviePass.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviePass.Controllers
{
    public class MovieController : Controller
    {

        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movie
        public ActionResult Index()
        {
            var moviesList = _context.Movies.Include(c=>c.Genre).ToList();
            return View(moviesList);
        }

        public ActionResult Details(int id)
        {
            var movieDetails = _context.Movies.SingleOrDefault(c => c.Id == id);
            return View(movieDetails);
        }


        public ActionResult New()
        {

            var viewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };

            ViewBag.Title = "New";
            return View("CreateMovie", viewModel);
        }


        public ActionResult Edit(int id)
        {
            var movieEdit = _context.Movies.SingleOrDefault(c => c.Id == id);

            if(movieEdit.Id==0)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel()
            {
                Movies = movieEdit,

                Genres = _context.Genres.ToList()
            };

            ViewBag.Title = "Edit";
            return View("CreateMovie", viewModel);
        }

        [HttpPost]
        public ActionResult Save(MovieFormViewModel viewModel)
        {
            if (viewModel.Movies.Id == 0)
            {
                _context.Movies.Add(viewModel.Movies);
            }
            else
            {
                var movieSelectDb = _context.Movies.Single(c => c.Id == viewModel.Movies.Id);
                movieSelectDb.Name = viewModel.Movies.Name;
                movieSelectDb.ReleaseDate = viewModel.Movies.ReleaseDate;
                movieSelectDb.Genre = viewModel.Movies.Genre;
                movieSelectDb.NumberInStock = viewModel.Movies.NumberInStock;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }
    }
}