using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Models
{
    public enum TaskStatus
    {
        EMPTY,
        OPEN,
        INPROGRESS,
        FINISHED
    }

    public class TaskStatusModel
    {
        public TaskStatus Key { get; set; }
        public string Description { get; set; }
    }
}
