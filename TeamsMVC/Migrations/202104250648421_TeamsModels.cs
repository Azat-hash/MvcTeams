namespace TeamsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeamsModels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PlayerAntropometics", newName: "PlayerAntropometrics");
            AlterColumn("dbo.Teams", "Conference", c => c.Int());
            DropTable("dbo.PlayerViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlayerViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Position = c.Int(nullable: false),
                        TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Teams", "Conference", c => c.Int(nullable: false));
            RenameTable(name: "dbo.PlayerAntropometrics", newName: "PlayerAntropometics");
        }
    }
}
