using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelReservation.Models;

namespace HotelReservation.Data
{
    public class HotelReservationContext: DbContext
    {
        public HotelReservationContext(): base("HotelReservationContext")
        {

        }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<BedType> BedTypes { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerType> CustomerTypes { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<User> Users { get; set; }

    }
}