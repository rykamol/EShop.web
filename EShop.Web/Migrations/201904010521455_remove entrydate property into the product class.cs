namespace EShop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeentrydatepropertyintotheproductclass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "EntryDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "EntryDate", c => c.DateTime(nullable: false));
        }
    }
}
