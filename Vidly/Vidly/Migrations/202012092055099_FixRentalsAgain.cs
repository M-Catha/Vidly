namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRentalsAgain : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Rentals");
            CreateTable(
                "dbo.Rentals",
                c => new
                {
                    Id = c.Byte(nullable: false, identity: true),
                    DateRented = c.DateTime(nullable: false),
                    DateReturned = c.DateTime(nullable: true)
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Rentals", "Customer_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "Movie_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "Customer_Id");
            CreateIndex("dbo.Rentals", "Movie_Id");
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropTable("dbo.Rentals");
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropColumn("dbo.Rentals", "Movie_Id");
            DropColumn("dbo.Rentals", "Customer_Id");
        }
    }
}
