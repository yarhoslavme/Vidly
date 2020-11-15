using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> movies = new List<Movie> {
            new Movie {Id = 1, Name = "Shrek"},
            new Movie {Id = 2, Name = "Wall-e"}
        };

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie { Name = "Shrek!" };
            return View(movie);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Index()
        {
            var model = new MoviesViewModel
            {
                Movies = movies
            };

            return View(model);
        }

    }
}