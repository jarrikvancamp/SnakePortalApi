namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passwordRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PortalUsers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.PortalUsers", "Salt", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PortalUsers", "Salt", c => c.String());
            AlterColumn("dbo.PortalUsers", "Password", c => c.String());
        }
    }
}
