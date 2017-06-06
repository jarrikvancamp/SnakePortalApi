namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapIDAddedToScore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scores", "MapId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Scores", "MapId");
        }
    }
}
