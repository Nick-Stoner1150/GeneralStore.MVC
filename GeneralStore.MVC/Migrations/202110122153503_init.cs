namespace GeneralStore.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Transactions", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "ProductId" });
            DropIndex("dbo.Transactions", new[] { "CustomerID" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Customers");
        }
    }
}
