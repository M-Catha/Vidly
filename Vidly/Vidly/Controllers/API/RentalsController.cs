using System;
using System.Linq;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _DBContext;

        public RentalsController()
        {
            _DBContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals (RentalDTO newRental)
        {
            var customer = _DBContext.Customers.Single(c => c.Id == newRental.CustomerID);

            var movies = _DBContext.Movies.Where(m => newRental.MovieIDs.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0) return BadRequest("Movie is not available");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _DBContext.Rentals.Add(rental);
            }

            _DBContext.SaveChanges();
            return Ok();
        }
    }
}
