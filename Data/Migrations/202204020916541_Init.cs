namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        PostalCode = c.Int(nullable: false),
                        Customer_id = c.Int(),
                        Seller_id = c.Int(),
                        Shipper_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.Customer_id)
                .ForeignKey("dbo.Sellers", t => t.Seller_id)
                .ForeignKey("dbo.Shippers", t => t.Shipper_id)
                .Index(t => t.Customer_id)
                .Index(t => t.Seller_id)
                .Index(t => t.Shipper_id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 200),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NameOnCard = c.String(nullable: false, maxLength: 50),
                        CardNumber = c.String(nullable: false, maxLength: 16),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Customer_id = c.Int(),
                        Seller_id = c.Int(),
                        Shipper_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.Customer_id)
                .ForeignKey("dbo.Sellers", t => t.Seller_id)
                .ForeignKey("dbo.Shippers", t => t.Shipper_id)
                .Index(t => t.Customer_id)
                .Index(t => t.Seller_id)
                .Index(t => t.Shipper_id);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 200),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(maxLength: 11),
                        Customer_id = c.Int(),
                        Seller_id = c.Int(),
                        Shipper_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.Customer_id)
                .ForeignKey("dbo.Sellers", t => t.Seller_id)
                .ForeignKey("dbo.Shippers", t => t.Shipper_id)
                .Index(t => t.Customer_id)
                .Index(t => t.Seller_id)
                .Index(t => t.Shipper_id);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ShipperName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Weight = c.String(),
                        Discount = c.Single(nullable: false),
                        Category_id = c.Int(nullable: false),
                        Sellers_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.Category_id, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.Sellers_id, cascadeDelete: true)
                .Index(t => t.Category_id)
                .Index(t => t.Sellers_id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer_id = c.Int(),
                        Products_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.Customer_id)
                .ForeignKey("dbo.Products", t => t.Products_id)
                .Index(t => t.Customer_id)
                .Index(t => t.Products_id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        ParentID = c.Int(nullable: false),
                        Image_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Images", t => t.Image_id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.ParentID)
                .Index(t => t.ParentID)
                .Index(t => t.Image_id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Customer_id = c.Int(nullable: false),
                        Product_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.Customer_id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_id, cascadeDelete: true)
                .Index(t => t.Customer_id)
                .Index(t => t.Product_id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderSummary_id = c.Int(),
                        product_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.OrderSummaries", t => t.OrderSummary_id)
                .ForeignKey("dbo.Products", t => t.product_id)
                .Index(t => t.OrderSummary_id)
                .Index(t => t.product_id);
            
            CreateTable(
                "dbo.OrderSummaries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        OrderDate = c.String(),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsPaid = c.Boolean(nullable: false),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryStatus = c.String(),
                        Customer_id = c.Int(),
                        Shipper_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.Customer_id)
                .ForeignKey("dbo.Shippers", t => t.Shipper_id)
                .Index(t => t.Customer_id)
                .Index(t => t.Shipper_id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer_id = c.Int(nullable: false),
                        Product_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.Customer_id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_id, cascadeDelete: true)
                .Index(t => t.Customer_id)
                .Index(t => t.Product_id);
            
            CreateTable(
                "dbo.Wishlists",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Customers_id = c.Int(nullable: false),
                        Product_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.Customers_id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_id, cascadeDelete: true)
                .Index(t => t.Customers_id)
                .Index(t => t.Product_id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 200),
                        Permission = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ImagesProducts",
                c => new
                    {
                        Images_id = c.Int(nullable: false),
                        Product_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Images_id, t.Product_id })
                .ForeignKey("dbo.Images", t => t.Images_id, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.Product_id, cascadeDelete: false)
                .Index(t => t.Images_id)
                .Index(t => t.Product_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wishlists", "Product_id", "dbo.Products");
            DropForeignKey("dbo.Wishlists", "Customers_id", "dbo.Customers");
            DropForeignKey("dbo.Products", "Sellers_id", "dbo.Sellers");
            DropForeignKey("dbo.Reviews", "Product_id", "dbo.Products");
            DropForeignKey("dbo.Reviews", "Customer_id", "dbo.Customers");
            DropForeignKey("dbo.Orders", "product_id", "dbo.Products");
            DropForeignKey("dbo.OrderSummaries", "Shipper_id", "dbo.Shippers");
            DropForeignKey("dbo.Orders", "OrderSummary_id", "dbo.OrderSummaries");
            DropForeignKey("dbo.OrderSummaries", "Customer_id", "dbo.Customers");
            DropForeignKey("dbo.Likes", "Product_id", "dbo.Products");
            DropForeignKey("dbo.Likes", "Customer_id", "dbo.Customers");
            DropForeignKey("dbo.Products", "Category_id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentID", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Image_id", "dbo.Images");
            DropForeignKey("dbo.ImagesProducts", "Product_id", "dbo.Products");
            DropForeignKey("dbo.ImagesProducts", "Images_id", "dbo.Images");
            DropForeignKey("dbo.Carts", "Products_id", "dbo.Products");
            DropForeignKey("dbo.Carts", "Customer_id", "dbo.Customers");
            DropForeignKey("dbo.Phones", "Shipper_id", "dbo.Shippers");
            DropForeignKey("dbo.Cards", "Shipper_id", "dbo.Shippers");
            DropForeignKey("dbo.Addresses", "Shipper_id", "dbo.Shippers");
            DropForeignKey("dbo.Phones", "Seller_id", "dbo.Sellers");
            DropForeignKey("dbo.Phones", "Customer_id", "dbo.Customers");
            DropForeignKey("dbo.Cards", "Seller_id", "dbo.Sellers");
            DropForeignKey("dbo.Addresses", "Seller_id", "dbo.Sellers");
            DropForeignKey("dbo.Cards", "Customer_id", "dbo.Customers");
            DropForeignKey("dbo.Addresses", "Customer_id", "dbo.Customers");
            DropIndex("dbo.ImagesProducts", new[] { "Product_id" });
            DropIndex("dbo.ImagesProducts", new[] { "Images_id" });
            DropIndex("dbo.Wishlists", new[] { "Product_id" });
            DropIndex("dbo.Wishlists", new[] { "Customers_id" });
            DropIndex("dbo.Reviews", new[] { "Product_id" });
            DropIndex("dbo.Reviews", new[] { "Customer_id" });
            DropIndex("dbo.OrderSummaries", new[] { "Shipper_id" });
            DropIndex("dbo.OrderSummaries", new[] { "Customer_id" });
            DropIndex("dbo.Orders", new[] { "product_id" });
            DropIndex("dbo.Orders", new[] { "OrderSummary_id" });
            DropIndex("dbo.Likes", new[] { "Product_id" });
            DropIndex("dbo.Likes", new[] { "Customer_id" });
            DropIndex("dbo.Categories", new[] { "Image_id" });
            DropIndex("dbo.Categories", new[] { "ParentID" });
            DropIndex("dbo.Carts", new[] { "Products_id" });
            DropIndex("dbo.Carts", new[] { "Customer_id" });
            DropIndex("dbo.Products", new[] { "Sellers_id" });
            DropIndex("dbo.Products", new[] { "Category_id" });
            DropIndex("dbo.Phones", new[] { "Shipper_id" });
            DropIndex("dbo.Phones", new[] { "Seller_id" });
            DropIndex("dbo.Phones", new[] { "Customer_id" });
            DropIndex("dbo.Cards", new[] { "Shipper_id" });
            DropIndex("dbo.Cards", new[] { "Seller_id" });
            DropIndex("dbo.Cards", new[] { "Customer_id" });
            DropIndex("dbo.Addresses", new[] { "Shipper_id" });
            DropIndex("dbo.Addresses", new[] { "Seller_id" });
            DropIndex("dbo.Addresses", new[] { "Customer_id" });
            DropTable("dbo.ImagesProducts");
            DropTable("dbo.Admins");
            DropTable("dbo.Wishlists");
            DropTable("dbo.Reviews");
            DropTable("dbo.OrderSummaries");
            DropTable("dbo.Orders");
            DropTable("dbo.Likes");
            DropTable("dbo.Images");
            DropTable("dbo.Categories");
            DropTable("dbo.Carts");
            DropTable("dbo.Products");
            DropTable("dbo.Shippers");
            DropTable("dbo.Phones");
            DropTable("dbo.Sellers");
            DropTable("dbo.Cards");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
