namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shippers", "Email", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Shippers", "Password", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Shippers", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shippers", "Balance");
            DropColumn("dbo.Shippers", "Password");
            DropColumn("dbo.Shippers", "Email");
        }
    }
}
