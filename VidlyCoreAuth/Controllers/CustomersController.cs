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
        private List<Customer> customers = new List<Customer>() {
                new Customer { Name = "John Smith", Id = 1 },
                new Customer { Name = "Mary Williams" , Id = 2}
            };

        public IActionResult Index()
        {
            var viewModel = new CustomerViewModel() {
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("customers/details/{id}")]
        public IActionResult Details(int id)
        {
            var customer = customers.FirstOrDefault(cust => cust.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
    }
}