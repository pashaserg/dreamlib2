namespace DreamLib2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datetimeforsongcolumn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Src = c.String(),
                        Cover = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GenreSongs",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        Song_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Song_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.Song_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Song_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GenreSongs", "Song_Id", "dbo.Songs");
            DropForeignKey("dbo.GenreSongs", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Songs", "ArtistId", "dbo.Artists");
            DropIndex("dbo.GenreSongs", new[] { "Song_Id" });
            DropIndex("dbo.GenreSongs", new[] { "Genre_Id" });
            DropIndex("dbo.Songs", new[] { "ArtistId" });
            DropTable("dbo.GenreSongs");
            DropTable("dbo.Genres");
            DropTable("dbo.Songs");
            DropTable("dbo.Artists");
        }
    }
}
