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
        public ActionResult Index()
        {
            var list = _context.Menus.Include("Category").OrderByDescending(m => m.Id).ToList();
            return View(list);

            
        }

        public ActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
           
        }
        [HttpPost]
        public ActionResult Create(Menu menu)
        {
            if (ModelState.IsValid)
            {
                _context.Menus.Add(menu);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(menu);
        }
    }
}