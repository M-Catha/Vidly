namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRentalsTable : DbMigration
    {
        public override void Up()
        {

            Sql("DROP TABLE dbo.Rentals");
            Sql("CREATE TABLE [dbo].[Rentals] ([Id] INT IDENTITY(1, 1) NOT NULL, [DateRented] DATETIME NOT NULL, [DateReturned] DATETIME NULL, [Customer_Id]  INT DEFAULT((0)) NOT NULL, [Movie_Id] INT DEFAULT((0)) NOT NULL, CONSTRAINT[PK_dbo.Rentals] PRIMARY KEY CLUSTERED([Id] ASC), CONSTRAINT[FK_dbo.Rentals_dbo.Customers_Customer_Id] FOREIGN KEY([Customer_Id]) REFERENCES[dbo].[Customers]([Id]) ON DELETE CASCADE, CONSTRAINT[FK_dbo.Rentals_dbo.Movies_Movie_Id] FOREIGN KEY([Movie_Id]) REFERENCES[dbo].[Movies]([Id]) ON DELETE CASCADE ); CREATE NONCLUSTERED INDEX[IX_Customer_Id] ON[dbo].[Rentals]([Customer_Id] ASC); CREATE NONCLUSTERED INDEX[IX_Movie_Id] ON[dbo].[Rentals]([Movie_Id] ASC); ");
        }
        
        public override void Down()
        {
        }
    }
}
