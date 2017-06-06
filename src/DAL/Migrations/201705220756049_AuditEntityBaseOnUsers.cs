namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuditEntityBaseOnUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PortalUsers", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.PortalUsers", "ModifiedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.PortalUsers", "CreatedDate");
            DropColumn("dbo.PortalUsers", "LastModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PortalUsers", "LastModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PortalUsers", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.PortalUsers", "ModifiedOn");
            DropColumn("dbo.PortalUsers", "CreatedOn");
        }
    }
}
