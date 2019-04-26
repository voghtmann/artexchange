namespace MVCGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        ArtistName = c.String(maxLength: 50),
                        Birth = c.DateTime(nullable: false),
                        Death = c.DateTime(),
                        CountryOfOrigin = c.String(),
                        DominantStyle = c.String(maxLength: 50),
                        ArtistDesc = c.String(),
                        ArtistUrl = c.String(),
                    })
                .PrimaryKey(t => t.ArtistID);
            
            CreateTable(
                "dbo.Artwork",
                c => new
                    {
                        ArtworkID = c.Int(nullable: false, identity: true),
                        ArtistID = c.Int(nullable: false),
                        PatronID = c.Int(nullable: false),
                        ExhibitionID = c.Int(nullable: false),
                        Title = c.String(),
                        Year = c.Int(),
                        Description = c.String(),
                        Likes = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        CurrentValue = c.Decimal(precision: 18, scale: 2),
                        Medium = c.String(),
                    })
                .PrimaryKey(t => t.ArtworkID)
                .ForeignKey("dbo.Artist", t => t.ArtistID, cascadeDelete: true)
                .ForeignKey("dbo.Exhibition", t => t.ExhibitionID, cascadeDelete: true)
                .ForeignKey("dbo.Patron", t => t.PatronID, cascadeDelete: true)
                .Index(t => t.ArtistID)
                .Index(t => t.PatronID)
                .Index(t => t.ExhibitionID);
            
            CreateTable(
                "dbo.Exhibition",
                c => new
                    {
                        ExhibitionID = c.Int(nullable: false),
                        ExName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(),
                        Venue = c.String(),
                        City = c.String(),
                        ExDesc = c.String(),
                    })
                .PrimaryKey(t => t.ExhibitionID);
            
            CreateTable(
                "dbo.Patron",
                c => new
                    {
                        PatronID = c.Int(nullable: false, identity: true),
                        PatronName = c.String(),
                        EntityType = c.String(),
                        ContactPhone = c.String(),
                        ContactEmail = c.String(),
                    })
                .PrimaryKey(t => t.PatronID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Artwork", "PatronID", "dbo.Patron");
            DropForeignKey("dbo.Artwork", "ExhibitionID", "dbo.Exhibition");
            DropForeignKey("dbo.Artwork", "ArtistID", "dbo.Artist");
            DropIndex("dbo.Artwork", new[] { "ExhibitionID" });
            DropIndex("dbo.Artwork", new[] { "PatronID" });
            DropIndex("dbo.Artwork", new[] { "ArtistID" });
            DropTable("dbo.Patron");
            DropTable("dbo.Exhibition");
            DropTable("dbo.Artwork");
            DropTable("dbo.Artist");
        }
    }
}
