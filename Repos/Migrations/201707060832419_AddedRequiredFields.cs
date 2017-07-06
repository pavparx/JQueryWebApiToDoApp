namespace Repos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Tasks", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Tasks", "Description", c => c.String());
            AlterColumn("dbo.Tasks", "Name", c => c.String());
        }
    }
}
