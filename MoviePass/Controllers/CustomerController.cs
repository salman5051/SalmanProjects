using MoviePass.Models;
using System.Data.Entity;
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

        public ActionResult Details(int id)
        {
            var customersList = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c=> c.Id==id);
            if(customersList==null)
            {
                return HttpNotFound();
            }
            return View(customersList);
        }
    }
}