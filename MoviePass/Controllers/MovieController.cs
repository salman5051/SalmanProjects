using MoviePass.Models;
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
            var moviesList = _context.Movies.ToList();
            return View(moviesList);
        }

        public ActionResult Details(int id)
        {
            var movieDetails = _context.Movies.SingleOrDefault(c => c.Id == id);
            return View(movieDetails);
        }
    }
}