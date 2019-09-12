using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelReservation.Models
{
    public class Menu
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Count { get; set; }

        public decimal Price { get; set; }

        public bool Status { get; set; }
        [Display(Name="Category")]
        public int CatgeoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}