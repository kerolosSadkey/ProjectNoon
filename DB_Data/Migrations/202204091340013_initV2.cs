namespace DB_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initV2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderSummaries", "Shipper_id", "dbo.Shippers");
            DropIndex("dbo.OrderSummaries", new[] { "Shipper_id" });
            AlterColumn("dbo.OrderSummaries", "Shipper_id", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderSummaries", "Shipper_id");
            AddForeignKey("dbo.OrderSummaries", "Shipper_id", "dbo.Shippers", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderSummaries", "Shipper_id", "dbo.Shippers");
            DropIndex("dbo.OrderSummaries", new[] { "Shipper_id" });
            AlterColumn("dbo.OrderSummaries", "Shipper_id", c => c.Int());
            CreateIndex("dbo.OrderSummaries", "Shipper_id");
            AddForeignKey("dbo.OrderSummaries", "Shipper_id", "dbo.Shippers", "id");
        }
    }
}
