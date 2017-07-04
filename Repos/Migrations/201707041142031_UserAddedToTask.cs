namespace Repos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAddedToTask : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Tasks", "CreatorId");
            AddForeignKey("dbo.Tasks", "CreatorId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "CreatorId", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "CreatorId" });
        }
    }
}
