namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameLicenseColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DriversLicense", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.AspNetUsers", "DrivingLicense");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.AspNetUsers", "DriversLicense");
        }
    }
}
