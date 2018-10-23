using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VidlyCoreAuth.Models;
using VidlyCoreAuth.ViewModels;

namespace VidlyCoreAuth.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> movies = new List<Movie>() {
                new Movie { Name = "Shrek", Id = 1 },
                new Movie { Name = "Wall-e" , Id = 2}
            };

        public IActionResult Index()
        {
            var viewModel = new MovieViewModel()
            {
                Movies = movies
            };

            return View(viewModel);
        }

        [Route("movies/details/{id}")]
        public IActionResult Details(int id)
        {
            var movie = movies.FirstOrDefault(mov => mov.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // GET: Movies/Random
        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>() {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel() {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }
    }
}