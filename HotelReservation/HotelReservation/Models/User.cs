using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelReservation.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required,MaxLength(50)]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Required, MaxLength(50)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        [Required, MaxLength(100)]
        public string Password { get; set; }
        [Display(Name = "Role")]
        public int GroupId { get; set; }

        public Group Group { get; set; }

        public ICollection<Booking> Bookings { get; set; }


    }
}