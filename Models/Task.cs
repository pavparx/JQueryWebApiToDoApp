using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Task
    {
        public int Id { get; set; }
        [ForeignKey("user")]
        public int creatorId { get; set; }
        public User user { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }

    }
}