namespace Repos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tasks", "creatorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "creatorId");
            AddForeignKey("dbo.Tasks", "creatorId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "creatorId", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "creatorId" });
            DropColumn("dbo.Tasks", "creatorId");
            DropTable("dbo.Users");
        }
    }
}
