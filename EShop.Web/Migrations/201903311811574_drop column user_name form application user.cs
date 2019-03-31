namespace EShop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropcolumnuser_nameformapplicationuser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "User_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "User_Name", c => c.String());
        }
    }
}
