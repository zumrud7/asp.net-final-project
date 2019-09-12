using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelReservation.Models
{
    public class BedType
    {
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}