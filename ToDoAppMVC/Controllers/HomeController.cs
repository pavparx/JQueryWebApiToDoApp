using IRepositories;
using System.Collections.Generic;
using System.Web.Mvc;
using ToDoAppMVC.ViewModels;


namespace ToDoAppMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly ITaskRepository _tasksRepo;
        public HomeController(ITaskRepository tasksRepo)
        {


            _tasksRepo = tasksRepo;

        }

        // GET: Home
        public ActionResult Index()

        {
            var model = new TasksVM { Tasks = _tasksRepo.GetTasks() };
            return View(model);
        }

        public ActionResult SearchTask(string keyword)
        {
            var model = new TasksVM { Tasks = _tasksRepo.GetTasks() };

            List<Models.Task> tempList = new List<Models.Task>();

            foreach (var task in model.Tasks)
            {
                if (task.Name.Contains(keyword) || task.Description.Contains(keyword))
                {
                    tempList.Add(task);

                }

            }

            var result = new TasksVM { Tasks = tempList };
            return View("Index", result);
        }






    }
}