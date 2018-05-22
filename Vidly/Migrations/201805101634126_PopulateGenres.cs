namespace MovieStop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Action'), " +
                "('Comedy'), ('Family'), ('Romance'), ('Thriller')");
        }
        
        public override void Down()
        {
        }
    }
}
