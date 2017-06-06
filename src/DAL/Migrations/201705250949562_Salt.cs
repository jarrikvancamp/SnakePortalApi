namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Salt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PortalUsers", "Password", c => c.String());
            AddColumn("dbo.PortalUsers", "Salt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PortalUsers", "Salt");
            DropColumn("dbo.PortalUsers", "Password");
        }
    }
}
