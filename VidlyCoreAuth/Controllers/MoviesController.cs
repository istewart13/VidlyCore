﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyCoreAuth.Data;
using VidlyCoreAuth.Models;
using VidlyCoreAuth.ViewModels;

namespace VidlyCoreAuth.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();   
        }

        public IActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            var viewModel = new MovieViewModel()
            {
                Movies = movies
            };

            return View(viewModel);
        }

        [Route("movies/details/{id}")]
        public IActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(mov => mov.Id == id);
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