namespace IRHL.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        TeamID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        IsGoalie = c.Boolean(nullable: false),
                        WillGoalie = c.Boolean(nullable: false),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.PlayerID)
                .ForeignKey("dbo.Teams", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.TeamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "TeamID", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "TeamID" });
            DropTable("dbo.Players");
        }
    }
}
