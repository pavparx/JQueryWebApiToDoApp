namespace Repos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Users.AddOrUpdate(
            p => p.Id,
            new Models.User { Id = 1, Name = "Mark" },
            new Models.User { Id = 2, Name = "Karl" },
            new Models.User { Id = 3, Name = "David" }
          );
            context.Tasks.AddOrUpdate(
              p => p.Id,
              new Models.Task { Id = 1, CreatorId = 1, Name = "Groceries", Description = "Do the groceries", Done = false },
              new Models.Task { Id = 2, CreatorId = 2, Name = "Laundry", Description = "Do the laundry", Done = false },
              new Models.Task { Id = 3, CreatorId = 3, Name = "Dog", Description = "Feed the dog", Done = false }
            );


        }
    }
}
