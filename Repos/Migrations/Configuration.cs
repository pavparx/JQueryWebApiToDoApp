namespace Repos.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Repos.DbContextClass>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Repos.DbContextClass context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Tasks.AddOrUpdate(
              p => p.Id,
              new Models.Task { Id = 1, CreatorId = 1, Name = "Goat", Description = "Get me a goat", Done = false },
              new Models.Task { Id = 2, CreatorId = 1, Name = "Pebble", Description = "Get me a pebble", Done = true },
              new Models.Task { Id = 3, CreatorId = 2, Name = "Coal", Description = "Get me some coal", Done = false },
              new Models.Task { Id = 4, CreatorId = 3, Name = "Vladimir", Description = "Call Vladimir", Done = false }

            );

            context.Users.AddOrUpdate(
              p => p.Id,
              new User { Id = 1, Name = "MacGrecor" },
              new User { Id = 2, Name = "Leperjack" },
              new User { Id = 3, Name = "Katsuya" }

            );

        }
    }
}
