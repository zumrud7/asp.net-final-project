using HotelReservation.Data;
using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservation.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group

        private readonly HotelReservationContext _context;

        public GroupController()
        {
            _context = new HotelReservationContext();
        }
        public ActionResult Index()
        {
            var list = _context.Groups.OrderByDescending(g => g.Id).ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            ViewBag.Groups = _context.Groups.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Group grp)
        {

            if (ModelState.IsValid)
            {
                _context.Groups.Add(grp);
                _context.SaveChanges();
                return RedirectToAction("index");
            }


            return View(grp);
        }

        public ActionResult Edit(int id)
        {
            Group grp = _context.Groups.Find(id);

            if(grp == null)
            {
                return HttpNotFound();
            }

            ViewBag.Groups = _context.Groups.ToList();
            return View(grp);
        }

        [HttpPost]
        public ActionResult Edit(Group grp)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(grp).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            ViewBag.Groups = _context.Groups.OrderBy(g => g.Name).ToList();
            return View(grp);

        }

       
        public ActionResult Delete(int id)
        {
            Group grp = _context.Groups.Find(id);

            if(grp == null)
            {
                return HttpNotFound();
            }

            _context.Groups.Remove(grp);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}