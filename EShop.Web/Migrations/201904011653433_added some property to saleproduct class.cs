namespace EShop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsomepropertytosaleproductclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SaleProducts", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.SaleProducts", "TotalPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SaleProducts", "TotalPrice");
            DropColumn("dbo.SaleProducts", "Quantity");
        }
    }
}
