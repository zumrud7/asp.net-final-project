using HotelReservation.Data;
using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservation.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        private readonly HotelReservationContext _context;

        public CustomerController()
        {
            _context = new HotelReservationContext();
        }


        //Index page view
        public ActionResult Index()
        {

            //Ban access to page is user is not logged in 
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "login");
            }

            var list = _context.Customers.Include("CustomerType").OrderByDescending(c => c.Id).ToList();
            return View(list);
        }


        //Create page view
        public ActionResult Create()
        {
            ViewBag.CustomerTypes = _context.CustomerTypes.ToList();
            return View();
        }


        //Create page submit form
        [HttpPost]
        public ActionResult Create(Customer cst)
        {

            //Create customer is data is valid
            if (ModelState.IsValid)
            {
                _context.Customers.Add(cst);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(cst);
        }


        //Edit page view
        public ActionResult Edit(int id)
        {
            Customer cst = _context.Customers.Find(id);

            if(cst == null)
            {
                return HttpNotFound();
            }

            ViewBag.CustomerTypes = _context.CustomerTypes.ToList();
            return View(cst);
        }


        //Edit page submit form
        [HttpPost]
        public ActionResult Edit(Customer cst)
        {

            //Update customer is data is valid
            if (ModelState.IsValid)
            {
                _context.Entry(cst).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("index");

            }

            ViewBag.CustomerTypes = _context.CustomerTypes.ToList();
            return View(cst);
        }


        //Delete selected customer
        public ActionResult Delete(int id)
        {
            Customer cst = _context.Customers.Find(id);

                if(cst == null)
                {
                return HttpNotFound();
                }

            _context.Customers.Remove(cst);
            _context.SaveChanges();
            return RedirectToAction("index");
        }


    }
}