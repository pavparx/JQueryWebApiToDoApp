using System.Collections.Generic;

namespace ToDoAppMVC.ViewModels
{
    public class UsersAndTasksVM
    {

        public List<Models.Task> Tasks { get; set; }
        public List<Models.User> Users { get; set; }

    }
}