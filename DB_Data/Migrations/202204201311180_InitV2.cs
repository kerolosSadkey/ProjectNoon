namespace DB_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "NameArabic", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Products", "DescriptionArabic", c => c.String(maxLength: 500));
            AddColumn("dbo.Categories", "NameArabic", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Categories", "DescriptionArabic", c => c.String(maxLength: 200));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Categories", "DescriptionArabic");
            DropColumn("dbo.Categories", "NameArabic");
            DropColumn("dbo.Products", "DescriptionArabic");
            DropColumn("dbo.Products", "NameArabic");
        }
    }
}
