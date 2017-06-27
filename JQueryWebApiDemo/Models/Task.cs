using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JQueryWebApiDemo.Models
{
    public class Task
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }

    }
}