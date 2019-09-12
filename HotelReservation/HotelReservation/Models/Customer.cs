using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelReservation.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required,MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Customer Type")]
        public int CustomerTypeId { get; set; }

        public CustomerType CustomerType { get; set; }
    }
}