using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;


namespace Repos
{
    public class TaskRepository
    {


        DbContextClass.DbAccess Db = new DbContextClass.DbAccess();

        public List<Models.Task> GetTasks()
        {

            IQueryable<Models.Task> query = from data in Db.Tasks
                                            orderby data.Id
                                            select data;

            List<Models.Task> results = new List<Models.Task>(query);
            return results;
        }
    }
}
