using System.Collections.Generic;

namespace ToDoAppMVC.ViewModels
{
    public class TasksVM
    {
        public List<Models.Task> Tasks { get; set; }
        public string Keyword { get; set; }

    }
}