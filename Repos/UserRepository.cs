﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepositories;
using Models;
using System.Data.Entity;

namespace Repos
{
    public class UserRepository : IUserRepository
    {
        DbContextClass.DbAccess Db = new DbContextClass.DbAccess();
        public List<User> GetAll()
        {


            IQueryable<User> query = from data in Db.Users
                                     orderby data.Id
                                     select data;

            List<User> results = new List<User>(query);
            return results;
        }
    }
}
