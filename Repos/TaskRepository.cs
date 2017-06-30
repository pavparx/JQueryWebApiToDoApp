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

        //private static List<Models.Task> query = new List<Models.Task>
        //{
        //    new Models.Task() {Id=1, Name="Task1", Description="Desc1", Done=false },
        //    new Models.Task() {Id=2, Name="Task2", Description="Desc2", Done=false },
        //    new Models.Task() {Id=3, Name="Task3", Description="Desc3", Done=false },
        //};
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
