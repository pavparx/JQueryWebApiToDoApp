﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Models;
namespace Repos
{
    public class DbContextClass
    {
        public class DbAccess : DbContext
        {
            public DbAccess() : base("TaskDbConnection")
            {

                {
                    Database.SetInitializer<DbAccess>(new CreateDatabaseIfNotExists<DbAccess>());

                }
            }
            public DbSet<Models.Task> Tasks { get; set; }

        }

    }
}
