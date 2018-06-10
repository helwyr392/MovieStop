using MovieStop.Dtos;
using MovieStop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieStop.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        // Constructor
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/NewRental
        public IHttpActionResult GetNewRentals()
        {
            return Ok("GET: /api/NewRentals");
        }

        // POST: /api/NewRental
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available.");
                }

                // Decrement the number of movies available by 1
                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    RentedDate = DateTime.Now
                };

                // Add this rental to Rentals
                _context.Rentals.Add(rental);
            }

            // Save changes
            _context.SaveChanges();

            // Return
            return Ok();
        }

        // PUT

        // DELETE
    }
}
