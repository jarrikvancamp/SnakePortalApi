namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scores", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Scores", "ModifiedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.Scores", "CreatedDate");
            DropColumn("dbo.Scores", "LastModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scores", "LastModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Scores", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Scores", "ModifiedOn");
            DropColumn("dbo.Scores", "CreatedOn");
        }
    }
}
