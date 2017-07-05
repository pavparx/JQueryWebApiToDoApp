using IRepositories;
using System.Web.Mvc;
using ToDoAppMVC.ViewModels;

namespace ToDoAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _usersRepo;
        private readonly ITaskRepository _tasksRepo;
        public HomeController(ITaskRepository tasksRepo, IUserRepository usersRepo)
        {
            _tasksRepo = tasksRepo;
            _usersRepo = usersRepo;
        }

        // GET: Home
        public ActionResult Index()

        {
            var model = new UsersAndTasksVM { Tasks = _tasksRepo.GetTasks(), Users = _usersRepo.GetUsers() };
            return View(model);
        }
    }
}