using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using IRepositories;

namespace JQueryWebApiDemo.Controllers
{
    [RoutePrefix("api/tasks")]
    public class TaskListController : ApiController
    {
        private ITaskRepository _IRepoVar;


        public TaskListController(ITaskRepository IRepovar)
        {
            _IRepoVar = IRepovar;
        }



        [HttpGet]
        [Route]
        public List<Task> GetTasks()
        {

            return _IRepoVar.GetTasks();
        }


    }
}
