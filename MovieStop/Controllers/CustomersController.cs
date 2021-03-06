﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MovieStop.Models;
using MovieStop.ViewModels;

namespace MovieStop.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        // Constructor 
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: /Customers
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View();

            return View("ReadOnlyIndex");
        }

        // GET: /Customers/Details
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        // GET: /Customers/New
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        //GET: /Customers/Edit
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel(customer)
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter,
                MembershipTypeID = customer.MembershipTypeID,
                Birthdate = customer.Birthdate,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        // POST: /Customers/New
        // POST: /Customers/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Customer customer)
        {
            if (!(ModelState.IsValid))
            {
                var viewModel = new CustomerFormViewModel(customer)
                {
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.FirstName = customer.FirstName;
                customerInDb.LastName = customer.LastName;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeID = customer.MembershipTypeID;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}