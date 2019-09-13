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
        public ActionResult Index()
        {
            var list = _context.Customers.Include("CustomerType").OrderByDescending(c => c.Id).ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            ViewBag.CustomerTypes = _context.CustomerTypes.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer cst)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(cst);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(cst);
        }

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

        [HttpPost]
        public ActionResult Edit(Customer cst)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(cst).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("index");

            }

            ViewBag.CustomerTypes = _context.CustomerTypes.ToList();
            return View(cst);
        }

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