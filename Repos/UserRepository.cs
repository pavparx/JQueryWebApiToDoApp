using System;
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
        public List<User> GetUsers()
        {

            using (DbContextClass Db = new DbContextClass())
            {
                IQueryable<User> query = from data in Db.Users
                                         orderby data.Id
                                         select data;

                List<User> results = new List<User>(query);


                return results;
            }
        }
    }
}
