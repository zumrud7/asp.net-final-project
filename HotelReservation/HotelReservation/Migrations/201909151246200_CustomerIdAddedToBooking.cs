namespace HotelReservation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerIdAddedToBooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "CustomerId");
            AddForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropColumn("dbo.Bookings", "CustomerId");
        }
    }
}
