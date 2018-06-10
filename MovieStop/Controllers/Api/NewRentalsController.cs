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
            throw new NotImplementedException();
        }

        // PUT

        // DELETE
    }
}
