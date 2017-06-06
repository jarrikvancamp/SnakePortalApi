namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogposts", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.PortalUsers", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Scores", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.FeedEntries", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FeedEntries", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Scores", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PortalUsers", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Blogposts", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
