namespace MVCGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthOnNames1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exhibition", "ExDesc", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exhibition", "ExDesc", c => c.String());
        }
    }
}
