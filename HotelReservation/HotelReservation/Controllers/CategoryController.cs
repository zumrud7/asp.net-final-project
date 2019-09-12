﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelReservation.Data;
using HotelReservation.Models;

namespace HotelReservation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly HotelReservationContext _context;

        public CategoryController()
        {
            _context = new HotelReservationContext();
        }
        public ActionResult Index()
        {
            var list = _context.Categories.OrderByDescending(c => c.Id).ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category ctg)
        {

            if (ModelState.IsValid)
            {
                _context.Categories.Add(ctg);
                _context.SaveChanges();

                return RedirectToAction("index");
            }


            return View(ctg);
        }

        public ActionResult Edit(int id)
        {
            Category ctg = _context.Categories.Find(id);

            if (ctg == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(ctg);
        }

        [HttpPost]
        public ActionResult Edit(Category ctg)
        {

            if (ModelState.IsValid)
            {
                _context.Entry(ctg).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("index");
        }

        ViewBag.Categories = _context.Categories.OrderBy(c => c.Name).ToList();

            return View(ctg);
        }

        public ActionResult Delete(int id)
        {
            Category ctg = _context.Categories.Find(id);

            if (ctg == null)
            {
                return HttpNotFound();
            }

            _context.Categories.Remove(ctg);
            _context.SaveChanges();

            return RedirectToAction("index");
        }



    }
}