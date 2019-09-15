using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelReservation.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Display(Name ="User")]
        public int UserId { get; set; }

        public User User { get; set; }
        [Display(Name = "Check in")]
        public DateTime CheckIn { get; set; }
        [Display(Name = "Check out")]
        public DateTime CheckOut { get; set; }
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }
        [Display(Name = "Room No")]
        public int RoomId { get; set; }

        public bool Status { get; set; }

        public Room Room { get; set; }
        [Display(Name = "Restaurant Order")]
        public int MenuId { get; set; }

        public Menu Menu { get; set; }
        [Display(Name ="Customer Name")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        
    }
}