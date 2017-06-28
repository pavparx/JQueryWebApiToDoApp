using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using Repos;

namespace JQueryWebApiDemo.Controllers
{
    [RoutePrefix("api/tasks")]
    public class TaskListController : ApiController
    {

        TaskRepository RepoVar = new TaskRepository();

        [HttpGet]
        [Route]
        public List<Task> GetTasks()
        {

            return RepoVar.GetTasks();
        }


    }
}
