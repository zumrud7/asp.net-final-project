using HotelReservation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelReservation.Models;

namespace HotelReservation.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu

        private readonly HotelReservationContext _context;

        public MenuController()
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


            var list = _context.Menus.Include("Category").OrderByDescending(m => m.Id).ToList();
            return View(list);

            
        }


        //Create page view
        public ActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
           
        }


        //Create page submit form
        [HttpPost]
        public ActionResult Create(Menu menu)
        {

            //Create menu item if data is valid
            if (ModelState.IsValid)
            {
                _context.Menus.Add(menu);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(menu);
        }
        

        //Edit page view
        public ActionResult Edit(int id)
        {
            Menu menu = _context.Menus.Find(id);

            if(menu == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = _context.Categories.ToList();

            return View(menu);
        }


        //Edit page submit form
        [HttpPost]
        public ActionResult Edit(Menu menu)
        {

            //Update menu info if data is valid
            if (ModelState.IsValid)
            {
                _context.Entry(menu).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("index");
            }
            ViewBag.Categories = _context.Categories.ToList();

            return View(menu);

        }


        //Delete selected menu item
     
        public ActionResult Delete(int id)
        {
            Menu menu = _context.Menus.Find(id);

            if(menu == null)
            {
                return HttpNotFound();
            }
            _context.Menus.Remove(menu);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}