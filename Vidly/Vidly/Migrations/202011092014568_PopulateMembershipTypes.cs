namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate, Name) VALUES (1, 0, 0, 0, 'Pay As You Go');");
            Sql("INSERT INTO dbo.MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate, Name) VALUES (2, 30, 1, 10, 'Monthly');");
            Sql("INSERT INTO dbo.MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate, Name) VALUES (3, 90, 3, 15, 'Quarterly');");
            Sql("INSERT INTO dbo.MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate, Name) VALUES (4, 300, 12, 20, 'Annually');");
        }
        
        public override void Down()
        {
        }
    }
}
