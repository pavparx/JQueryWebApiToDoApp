using System.Data.Entity;
namespace Repos
{
    public class DbContextClass : DbContext
    {
        public DbContextClass() : base("TasksDBNew")
        {

            {
                Database.SetInitializer<DbContextClass>(new DropCreateDatabaseAlways<DbContextClass>());
                Database.Initialize(true);
                this.Configuration.ProxyCreationEnabled = false;
            }
        }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Models.User> Users { get; set; }



        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Models.Task>().HasRequired(t => t.User).WithRequiredDependent().Map(t => t.MapKey("CreatorId"));

        //}
    }
}
