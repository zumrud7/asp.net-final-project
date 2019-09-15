using HotelReservation.Data;
using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservation.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private readonly HotelReservationContext _context;

        public AdminController()
        {
            _context = new HotelReservationContext();
        }
        public ActionResult Index()
        {
            //Ban access to page is user is not logged in 
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "login");
            }

            var list = _context.Users.Include("Group").OrderByDescending(u => u.Id).ToList();
            return View(list);
        }


        //Create Page View
        public ActionResult Create()
        {
            ViewBag.Groups = _context.Groups.ToList();
            return View();
        }



        //Create Page Submit form
        [HttpPost]
        public ActionResult Create(User usr)
        {
            //Submit form if data is valid
            if (ModelState.IsValid)
            {
                _context.Users.Add(usr);
                _context.SaveChanges();
                return RedirectToAction("index");
            }


            
            return View(usr);
        }

        
        //Edit Page View
        public ActionResult Edit(int id)
        {
            User usr = _context.Users.Find(id);

            if(usr == null)
            {
                return HttpNotFound();
            }
            ViewBag.Groups = _context.Groups.ToList();
            return View(usr);
        }


        //Edit page submit form
        [HttpPost]
        public ActionResult Edit(User usr)
        {

            //Update form if data valid
            if (ModelState.IsValid)
            {
                _context.Entry(usr).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            ViewBag.Groups = _context.Groups.OrderBy(g => g.Name).ToList();
            return View(usr);
        }


        //Delete selected user
        public ActionResult Delete(int id)
        {
            User usr = _context.Users.Find(id);

            if(usr == null)
            {
                return HttpNotFound();
            }

            _context.Users.Remove(usr);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}