namespace IRHL.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesReverted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Players", "TeamID", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "TeamID" });
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        TeamOneID = c.Int(nullable: false),
                        TeamOneGoals = c.Int(nullable: false),
                        TeamOnePIM = c.Int(nullable: false),
                        TeamTwoID = c.Int(nullable: false),
                        TeamTwoGoals = c.Int(nullable: false),
                        TeamTwoPIM = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameID);
            
            DropColumn("dbo.Teams", "GoalDifference");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teams", "GoalDifference", c => c.Int(nullable: false));
            DropTable("dbo.Games");
            CreateIndex("dbo.Players", "TeamID");
            AddForeignKey("dbo.Players", "TeamID", "dbo.Teams", "TeamID", cascadeDelete: true);
        }
    }
}
