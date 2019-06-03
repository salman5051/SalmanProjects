using MoviePass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviePass.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customersList = GetCustomers();
            return View(customersList);
        }

        public ActionResult Details(int id)
        {
            var customersList = GetCustomers().SingleOrDefault(c=> c.Id==id);
            return View(customersList);
        }

        private List<Customer> GetCustomers()
        {
            var customerList = new List<Customer>
            {
                new Customer { Id = 1, Name= "Salman"},

                new Customer { Id = 2, Name= "Shahanaz"},

                new Customer { Id = 3, Name= "Naveen"},

                new Customer { Id = 4, Name= "Bhargav"},

                new Customer { Id = 5, Name= "Shalini"},

                new Customer { Id = 6, Name= "Vanitha"}
            };
            return customerList;
        }
    }
}