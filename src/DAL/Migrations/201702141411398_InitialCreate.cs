using System.Data.Entity.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.PortalUsers",
                    c => new
                    {
                        Id = c.Int(false, true),
                        UserName = c.String(false, 128),
                        Email = c.String(false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        SexId = c.Int(false),
                        NationalityId = c.Int(false),
                        LocationId = c.Int(false),
                        CreatedDate = c.DateTime(false),
                        LastModifiedDate = c.DateTime(false)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Scores",
                    c => new
                    {
                        Id = c.Int(false, true),
                        PlayerScore = c.Int(false),
                        UserId = c.Int(false),
                        CreatedDate = c.DateTime(false),
                        LastModifiedDate = c.DateTime(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PortalUsers", t => t.UserId, true)
                .Index(t => t.UserId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Scores", "UserId", "dbo.PortalUsers");
            DropIndex("dbo.Scores", new[] {"UserId"});
            DropTable("dbo.Scores");
            DropTable("dbo.PortalUsers");
        }
    }
}