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
            var customers = new List<Customer>() {
                new Customer { Name = "John Smith", Id = 1 },
                new Customer { Name = "Mary Williams" , Id = 2}
            };

            var viewModel = new CustomerViewModel() {
                Customers = customers
            };

            return View(viewModel);
        }
    }
}