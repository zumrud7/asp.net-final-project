using HotelReservation.Data;
using HotelReservation.Helpers;
using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservation.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room

        private readonly HotelReservationContext _context;

        public RoomController()
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
            var list = _context.Rooms.Include("BedType").OrderByDescending(r => r.Id).ToList();
            return View(list);
        }


        //Create page view
        public ActionResult Create()
        {
            ViewBag.BedTypes = _context.BedTypes.OrderBy(b => b.Name).ToList();
            return View();
        }


        //Create page submit form
        [HttpPost]
        public ActionResult Create(Room room)
        {

            // File size verification
            if (room.File.ContentLength / 1024 / 1024 > 1)
            {
                ModelState.AddModelError("File", "Uploaded file size cannot exceed 1MB.");
            }


            //Create room if data is valid
            if (ModelState.IsValid)
            {
                room.Photo = FileManager.Upload(room.File);
                
                _context.Rooms.Add(room);
                _context.SaveChanges();

                return RedirectToAction("index");
            }


            ViewBag.BedTypes = _context.BedTypes.OrderBy(b => b.Name).ToList();

            return View(room);
        }


        //Edit page view
        public ActionResult Edit(int id)
        {
            Room room = _context.Rooms.Find(id);

            if(room == null)
            {
                return HttpNotFound();

            }

            ViewBag.BedTypes = _context.BedTypes.OrderBy(b => b.Name).ToList();
            return View(room);
        }


        //Edit page submit form
        [HttpPost]
        public ActionResult Edit(Room room)
        {

            //Verify if uploaded file is valid
            if(room.File != null)
            {
                if(room.File.ContentLength/1024/1024 > 1)
                {
                    ModelState.AddModelError("File", "File size cannot exceed 1MB.");
                }
            }


            //Update room if data is valid
            if (ModelState.IsValid)
            {
                if(room.File != null)
                {
                    FileManager.Delete(room.Photo);
                    room.Photo = FileManager.Upload(room.File);
                }

                _context.Entry(room).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("index");

            }

            ViewBag.BedTypes = _context.BedTypes.OrderBy(b => b.Name).ToList();
            return View(room);
        }


        //Delete selected room
        public ActionResult Delete(int id)
        {
            Room room = _context.Rooms.Find(id);

            if(room == null)
            {
                return HttpNotFound();
            }

            if (room.File != null)
            {
                FileManager.Delete(room.Photo);

            }

            _context.Rooms.Remove(room);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


    }
}