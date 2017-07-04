using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Models;
namespace Repos
{
    public class DbContextClass : DbContext
    {
        public DbContextClass() : base("TasksDBNew")
        {

            {
                Database.SetInitializer<DbContextClass>(new DropCreateDatabaseIfModelChanges<DbContextClass>());

            }
        }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Models.User> Users { get; set; }



    }
}
