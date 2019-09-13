namespace HotelReservation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuFKCategoryIdCorrected : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Menus", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Menus", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.Menus", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Menus", "CategoryId");
            AddForeignKey("dbo.Menus", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Menus", "CatgeoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "CatgeoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Menus", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Menus", new[] { "CategoryId" });
            AlterColumn("dbo.Menus", "CategoryId", c => c.Int());
        }
    }
}
