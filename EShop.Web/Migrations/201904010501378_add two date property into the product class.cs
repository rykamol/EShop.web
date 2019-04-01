namespace EShop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtwodatepropertyintotheproductclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PurchaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "EntryDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "EntryDate");
            DropColumn("dbo.Products", "PurchaseDate");
        }
    }
}
