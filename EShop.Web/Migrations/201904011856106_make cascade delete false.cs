namespace EShop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makecascadedeletefalse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SaleProducts", "ProductId", "dbo.Products");
            AddForeignKey("dbo.SaleProducts", "ProductId", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleProducts", "ProductId", "dbo.Products");
            AddForeignKey("dbo.SaleProducts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
