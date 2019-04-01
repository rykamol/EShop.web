namespace EShop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class propertytypechangetosaleproductclass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SaleProducts", "ProductId_Id", "dbo.Products");
            DropForeignKey("dbo.SaleProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.SaleProducts", new[] { "Product_Id" });
            DropIndex("dbo.SaleProducts", new[] { "ProductId_Id" });
            RenameColumn(table: "dbo.SaleProducts", name: "Product_Id", newName: "ProductId");
            AlterColumn("dbo.SaleProducts", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.SaleProducts", "ProductId");
            AddForeignKey("dbo.SaleProducts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            DropColumn("dbo.SaleProducts", "ProductId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SaleProducts", "ProductId_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.SaleProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.SaleProducts", new[] { "ProductId" });
            AlterColumn("dbo.SaleProducts", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.SaleProducts", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.SaleProducts", "ProductId_Id");
            CreateIndex("dbo.SaleProducts", "Product_Id");
            AddForeignKey("dbo.SaleProducts", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.SaleProducts", "ProductId_Id", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
