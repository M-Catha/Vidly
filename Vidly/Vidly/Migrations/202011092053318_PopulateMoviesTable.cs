namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Movies (DateAdded, GenreId, Name, NumberInStock, ReleaseDate) VALUES ('11/9/2020', 2, 'Hangover', 4, '6/2/2009');");
            Sql("INSERT INTO dbo.Movies (DateAdded, GenreId, Name, NumberInStock, ReleaseDate) VALUES ('11/9/2020', 1, 'Die Hard', 5, '7/15/1988');");
            Sql("INSERT INTO dbo.Movies (DateAdded, GenreId, Name, NumberInStock, ReleaseDate) VALUES ('11/9/2020', 1, 'The Terminator', 2, '10/26/1984');");
            Sql("INSERT INTO dbo.Movies (DateAdded, GenreId, Name, NumberInStock, ReleaseDate) VALUES ('11/9/2020', 3, 'Toy Story', 9, '11/22/1995');");
            Sql("INSERT INTO dbo.Movies (DateAdded, GenreId, Name, NumberInStock, ReleaseDate) VALUES ('11/9/2020', 4, 'Titanic', 1, '12/19/1997');");
        }
        
        public override void Down()
        {
        }
    }
}
