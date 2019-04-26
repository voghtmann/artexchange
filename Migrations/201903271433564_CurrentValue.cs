namespace MVCGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrentValue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artwork", "CurrentValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artwork", "CurrentValue", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
