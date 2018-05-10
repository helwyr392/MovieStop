namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMetadataToMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "ReleasedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "GenreID", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreID");
            AddForeignKey("dbo.Movies", "GenreID", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreID", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreID" });
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "GenreID");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleasedDate");
            DropTable("dbo.Genres");
        }
    }
}
