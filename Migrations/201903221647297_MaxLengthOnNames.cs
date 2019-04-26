namespace MVCGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthOnNames : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artist", "ArtistName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Artist", "DominantStyle", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Artwork", "Title", c => c.String(maxLength: 50));
            AlterColumn("dbo.Exhibition", "ExName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Exhibition", "Venue", c => c.String(maxLength: 50));
            AlterColumn("dbo.Exhibition", "City", c => c.String(maxLength: 50));
            AlterColumn("dbo.Patron", "PatronName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Patron", "EntityType", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patron", "EntityType", c => c.String());
            AlterColumn("dbo.Patron", "PatronName", c => c.String());
            AlterColumn("dbo.Exhibition", "City", c => c.String());
            AlterColumn("dbo.Exhibition", "Venue", c => c.String());
            AlterColumn("dbo.Exhibition", "ExName", c => c.String());
            AlterColumn("dbo.Artwork", "Title", c => c.String());
            AlterColumn("dbo.Artist", "DominantStyle", c => c.String(maxLength: 50));
            AlterColumn("dbo.Artist", "ArtistName", c => c.String(maxLength: 50));
        }
    }
}
