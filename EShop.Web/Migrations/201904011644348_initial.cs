namespace EShop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SaleProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleDate = c.DateTime(nullable: false),
                        Product_Id = c.Int(),
                        ProductId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Products", t => t.ProductId_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.ProductId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleProducts", "ProductId_Id", "dbo.Products");
            DropForeignKey("dbo.SaleProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.SaleProducts", new[] { "ProductId_Id" });
            DropIndex("dbo.SaleProducts", new[] { "Product_Id" });
            DropTable("dbo.SaleProducts");
        }
    }
}
