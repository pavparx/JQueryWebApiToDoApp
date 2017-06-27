using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JQueryWebApiDemo.Models;

namespace JQueryWebApiDemo.Controllers
{
    [RoutePrefix("/api/tasks")]
    public class TaskListController : ApiController
    {
        private static List<Task> tasks = new List<Task>
        {
            new Task() { ID=1, Name="Groceries", Description="Do the groceries", Done=false },
            new Task() { ID=2, Name="Buy a car", Description="Choose brand and model", Done=false },
            new Task() { ID=3, Name="Clean dishes", Description="Clean the dishes", Done=false }
        };

        [HttpGet]
        [Route]
        public List<Task> GetTasks()
        {
            return tasks;
        }


    }
}
