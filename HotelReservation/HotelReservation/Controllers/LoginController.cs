using HotelReservation.Data;
using HotelReservation.Models;
using HotelReservation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservation.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

            private readonly HotelReservationContext _context;

            public LoginController()
        {
            _context = new HotelReservationContext();
        }


        //Index page view
        public ActionResult Index()
        {
            return View();
        }


        //Index page login submit form
        [HttpPost]
        public ActionResult Index(VwLogin login)
        {
            //Login if data is valid
            if (ModelState.IsValid)
            {

                //Find email from db
                User user = _context.Users.FirstOrDefault(u => u.Email == login.Email);
                if(user != null)
                {
                    if(user.Password == login.Password)
                    {
                        //Create user login session
                        Session["UserLogin"] = true;
                        Session["UserId"] = user.Id;
                        return RedirectToAction("index", "home");
                    }
                }

              
            }

            return View(login);
        }
    }
}