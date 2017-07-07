using IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace Repos
{
    public class TaskRepository : ITaskRepository
    {



        public List<Models.Task> GetTasks()
        {
            using (DbContextClass Db = new DbContextClass())
            {
                IQueryable<Models.Task> query = from data in Db.Tasks.Include("Creator")
                                                orderby data.Id
                                                select data;


                List<Models.Task> results = new List<Models.Task>(query);
                return results;
            }
            // return Db.Tasks.Where(t => t.Id.Equals(1)).OrderBy(d => d.Id).ToList();
        }
    }
}
