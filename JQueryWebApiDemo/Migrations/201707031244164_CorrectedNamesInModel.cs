namespace Repos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectedNamesInModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Tasks", new[] { "creatorId" });
            CreateIndex("dbo.Tasks", "CreatorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tasks", new[] { "CreatorId" });
            CreateIndex("dbo.Tasks", "creatorId");
        }
    }
}
