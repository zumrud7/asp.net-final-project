using HotelReservation.Data;
using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservation.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking

        private readonly HotelReservationContext _context;

        public BookingController()
        {
            _context = new HotelReservationContext();
        }

        //Booking Index Page view
        public ActionResult Index()
        {
            //Ban access to page is user is not logged in 
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "login");
            }


            var list = _context.Bookings.Include("Room").Include("Menu").Include("Customer").Include("User").ToList();
           
            return View(list);
        }


        //Booking create page view
        public ActionResult Create()
        {
            ViewBag.Rooms = _context.Rooms.OrderBy(r => r.Number).ToList();
            ViewBag.Customers = _context.Customers.OrderBy(c => c.LastName).ToList();
            ViewBag.Menus = _context.Menus.OrderBy(m => m.Name).ToList();
            ViewBag.Users = _context.Users.OrderBy(u => u.UserName).ToList();

            return View();
        }


        //Booking Create page submit form
        [HttpPost]
        public ActionResult Create(Booking bkg)
        {

            //Submit form is data is valid
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(bkg);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.Rooms = _context.Rooms.OrderBy(r => r.Number).ToList();
            ViewBag.Customers = _context.Customers.OrderBy(c => c.LastName).ToList();
            ViewBag.Menus = _context.Menus.OrderBy(m => m.Name).ToList();
            ViewBag.Users = _context.Users.OrderBy(u => u.UserName).ToList();

            return View(bkg);
        }


        //Booking Edit page view
        public ActionResult Edit(int id)
        {
            Booking bkg = _context.Bookings.Find(id);

            if(bkg == null)
            {
                return HttpNotFound();
            }

            ViewBag.Rooms = _context.Rooms.OrderBy(r => r.Number).ToList();
            ViewBag.Customers = _context.Customers.OrderBy(c => c.LastName).ToList();
            ViewBag.Menus = _context.Menus.OrderBy(m => m.Name).ToList();
            ViewBag.Users = _context.Users.OrderBy(u => u.UserName).ToList();

            return View(bkg);

        }




        //Edit Page submit form
        [HttpPost]
        public ActionResult Edit(Booking bkg)
        {

            //Update form if data is valid
            if (ModelState.IsValid)
            {
                _context.Entry(bkg).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("index");
            }

            ViewBag.Rooms = _context.Rooms.OrderBy(r => r.Number).ToList();
            ViewBag.Customers = _context.Customers.OrderBy(c => c.LastName).ToList();
            ViewBag.Menus = _context.Menus.OrderBy(m => m.Name).ToList();
            ViewBag.Users = _context.Users.OrderBy(u => u.UserName).ToList();

            return View(bkg);

        }

        
    }
}