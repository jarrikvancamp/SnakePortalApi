namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DT2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PortalUsers", "ModifiedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PortalUsers", "ModifiedOn", c => c.DateTime(nullable: false));
        }
    }
}
