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


        //Index page view
        public ActionResult Index()
        {
            //Ban access to page is user is not logged in 
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "login");
            }

            var list = _context.Groups.OrderByDescending(g => g.Id).ToList();
            return View(list);
        }


        //Create page view
        public ActionResult Create()
        {
            ViewBag.Groups = _context.Groups.ToList();
            return View();
        }


        //Create page submit form
        [HttpPost]
        public ActionResult Create(Group grp)
        {

            //Create role if data is valid
            if (ModelState.IsValid)
            {
                _context.Groups.Add(grp);
                _context.SaveChanges();
                return RedirectToAction("index");
            }


            return View(grp);
        }


        //Edit page view
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



        //Edit page submit form
        [HttpPost]
        public ActionResult Edit(Group grp)
        {

            //Update role is data is valid
            if (ModelState.IsValid)
            {
                _context.Entry(grp).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            ViewBag.Groups = _context.Groups.OrderBy(g => g.Name).ToList();
            return View(grp);

        }

       

        //Delete selected role
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