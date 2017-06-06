namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataparameters : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogposts", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Blogposts", "Message", c => c.String(nullable: false));
            AlterColumn("dbo.FeedEntries", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.FeedEntries", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FeedEntries", "Message", c => c.String());
            AlterColumn("dbo.FeedEntries", "Title", c => c.String());
            AlterColumn("dbo.Blogposts", "Message", c => c.String());
            AlterColumn("dbo.Blogposts", "Title", c => c.String());
        }
    }
}
