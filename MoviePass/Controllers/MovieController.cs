using MoviePass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviePass.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var moviesList = GetMovies();
            return View(moviesList);
        }

        public ActionResult Details(int id)
        {
            var movieDetails = GetMovies().SingleOrDefault(c => c.Id == id);
            return View(movieDetails);
        }
        private List<Movie> GetMovies()
        {
            var moviesList = new List<Movie>
            {
                new Movie { Id= 1, Name = "Avengers"},
                new Movie { Id= 2, Name = "Avengers-Ultron"},
                new Movie { Id= 3, Name = "Avengers-Infinity War"},
                new Movie { Id= 4, Name = "Avengers-End Game"},
                new Movie { Id= 5, Name = "IronMan"},
                new Movie { Id= 6, Name = "Captain America"},
                new Movie { Id= 7, Name = "Captain Marvel"},
                new Movie { Id= 8, Name = "Hulk"},
                new Movie { Id= 9, Name = "Spider Man"}
            };

            return moviesList;

        }
    }
}