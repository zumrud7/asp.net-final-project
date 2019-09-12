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
            var list = _context.Users.Include("Group").OrderByDescending(u => u.Id).ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            ViewBag.Groups = _context.Groups.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(User usr)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(usr);
                _context.SaveChanges();
                return RedirectToAction("index");
            }


            return View(usr);
        }

        
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

        [HttpPost]
        public ActionResult Edit(User usr)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(usr).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            ViewBag.Groups = _context.Groups.OrderBy(g => g.Name).ToList();
            return View(usr);
        }

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