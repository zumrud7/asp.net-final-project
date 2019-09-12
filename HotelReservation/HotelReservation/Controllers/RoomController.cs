using HotelReservation.Data;
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
            return View();
        }
    }
}