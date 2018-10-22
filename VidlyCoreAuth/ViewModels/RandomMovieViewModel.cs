using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidlyCoreAuth.Models;

namespace VidlyCoreAuth.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
