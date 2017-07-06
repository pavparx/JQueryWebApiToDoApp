using System.Data.Entity;
namespace Repos
{
    public class DbContextClass : DbContext
    {
        public DbContextClass() : base("TasksDBNew")
        {

            {
                Database.SetInitializer<DbContextClass>(new MigrateDatabaseToLatestVersion<DbContextClass, Migrations.Configuration>());
                this.Configuration.ProxyCreationEnabled = false;
            }
        }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Models.User> Users { get; set; }

    }
}
