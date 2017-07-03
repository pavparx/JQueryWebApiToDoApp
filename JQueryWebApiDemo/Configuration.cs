namespace Repos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Repos.DbContextClass.DbAccess>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Repos.DbContextClass.DbAccess context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Tasks.AddOrUpdate(
              p => p.Name,
              new Models.Task { Id = 1, CreatorId = 1, Name = "First Task", Description = "First Description", Done = false },
              new Models.Task { Id = 2, CreatorId = 2, Name = "Second Task", Description = "Second Description", Done = false },
              new Models.Task { Id = 3, CreatorId = 3, Name = "Third Task", Description = "Third Description", Done = false }

            );

            context.Users.AddOrUpdate(
              p => p.Name,
              new Models.User { Id = 1, Name = "Paul" },
              new Models.User { Id = 2, Name = "Jack" },
              new Models.User { Id = 3, Name = "Adam" }
            );
        }
    }
}
