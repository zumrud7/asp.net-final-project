﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelReservation.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Menu> Menus { get; set; }



    }
}