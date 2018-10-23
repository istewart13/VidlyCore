using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VidlyCoreAuth.Models;
using VidlyCoreAuth.ViewModels;

namespace VidlyCoreAuth.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            var customers = GetCustomers();

            var viewModel = new CustomerViewModel() {
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("customers/details/{id}")]
        public IActionResult Details(int id)
        {
            var customer = GetCustomers().FirstOrDefault(cust => cust.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        private List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
    }
}

