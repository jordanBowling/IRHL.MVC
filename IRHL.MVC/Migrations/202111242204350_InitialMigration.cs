namespace IRHL.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "TeamCaptain", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "TeamCaptain");
        }
    }
}
