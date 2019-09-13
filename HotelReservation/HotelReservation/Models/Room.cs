using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelReservation.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Room No")]
        public int Number { get; set; }

        public bool Status { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Display(Name ="Adult Capacity")]
        public int AdultCapacity { get; set; }
        [Required]
        [Display(Name = "Child Capacity")]
        public int ChildCapacity { get; set; }
        [Display(Name = "Bed Type")]
        public int BedTypeId { get; set; }

        public BedType BedType { get; set; }
        [Required,MaxLength(500)]
        public string Description { get; set; }

        public string Photo { get; set; }

        [NotMapped]
        public HttpPostedFileBase File { get; set; }

        public ICollection<Booking> Bookings { get; set; }



    }
}