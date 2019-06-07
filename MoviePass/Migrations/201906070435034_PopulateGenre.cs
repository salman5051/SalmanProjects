namespace MoviePass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Name) Values('Comedy')");
            Sql("INSERT INTO Genres(Name) Values('Romance')");
            Sql("INSERT INTO Genres(Name) Values('Action')");
            Sql("INSERT INTO Genres(Name) Values('Fantacy')");
            Sql("INSERT INTO Genres(Name) Values('Drama')");
            Sql("INSERT INTO Genres(Name) Values('Horror')");
            Sql("INSERT INTO Genres(Name) Values('Thriller')");
        }
        
        public override void Down()
        {
        }
    }
}
