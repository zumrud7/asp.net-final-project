using HotelReservation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservation.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        private readonly HotelReservationContext _context;

        public CustomerController()
        {
            _context = new HotelReservationContext();
        }
        public ActionResult Index()
        {
            var list = _context.Customers.Include("CustomerType").OrderByDescending(c => c.Id).ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}