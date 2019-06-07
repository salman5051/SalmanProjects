using MoviePass.Models;
using System.Data.Entity;
using MoviePass.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviePass.Controllers
{
    public class CustomerController : Controller
    {

        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customersList = _context.Customers.Include(c =>c.MembershipType).ToList();
            return View(customersList);
        }

       public ActionResult New()
        {
            var membersList = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes= membersList
            };

            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customers)
        {
            if(customers.Id==0)
            {
                _context.Customers.Add(customers);

            }
            else
            {
                var customerdb = _context.Customers.Single(c => c.Id == customers.Id);
                customerdb.Name = customers.Name;
                customerdb.Birthdate = customers.Birthdate;
                customerdb.MembershipType = customers.MembershipType;
                customerdb.IsSubscribedToNewsLetter = customers.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }
        public ActionResult Details(int id)
        {
            var customersList = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c=> c.Id==id);
            if(customersList==null)
            {
                return HttpNotFound();
            }
            return View(customersList);
        }

        public ActionResult Edit(int id)
        {
            var selectedCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (selectedCustomer == null)
            {
                HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel()
            {
                Customers = selectedCustomer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }


    }
}