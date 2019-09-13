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
        public ActionResult Index()
        {
            var list = _context.Rooms.Include("BedType").OrderByDescending(r => r.Id).ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            ViewBag.BedTypes = _context.BedTypes.OrderBy(b => b.Name).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Room room)
        {
            if (room.File.ContentLength / 1024 / 1024 > 1)
            {
                ModelState.AddModelError("File", "Uploaded file size cannot exceed 1MB.");
            }

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

        [HttpPost]
        public ActionResult Edit(Room room)
        {
            if(room.File != null)
            {
                if(room.File.ContentLength/1024/1024 > 1)
                {
                    ModelState.AddModelError("File", "File size cannot exceed 1MB.");
                }
            }

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