using System;
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
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public IActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            var viewModel = new CustomerViewModel() {
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("customers/details/{id}")]
        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(cust => cust.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
    }
}

