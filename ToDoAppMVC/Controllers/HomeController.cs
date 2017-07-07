using IRepositories;
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
    }
}