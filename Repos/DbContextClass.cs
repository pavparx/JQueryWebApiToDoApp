using Models;
using System.Data.Entity;
namespace Repos
{
    public class DbContextClass : DbContext
    {
        public DbContextClass() : base("TasksDBNewC")
        {

            {
                Database.SetInitializer<DbContextClass>(new MigrateDatabaseToLatestVersion<DbContextClass, Migrations.Configuration>());
                this.Configuration.ProxyCreationEnabled = false;
            }
        }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Models.User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Code First to ignore PluralizingTableName convention 
            // If you keep this convention then the generated tables will have pluralized names. 
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Task>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Task>().Property(a => a.Description).IsRequired();
            modelBuilder.Entity<User>().Property(a => a.Name).IsRequired();
        }

    }
}
