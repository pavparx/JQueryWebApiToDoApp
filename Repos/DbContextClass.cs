using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Models;
namespace Repos
{
    public class DbContextClass : DbContext
    {
        public DbContextClass() : base("TasksDBNew")
        {

            {
                Database.SetInitializer<DbContextClass>(new DropCreateDatabaseIfModelChanges<DbContextClass>());
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
