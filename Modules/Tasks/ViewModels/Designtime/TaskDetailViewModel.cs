using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;

namespace Tasks.ViewModels.Designtime
{
    public class TaskDetailViewModel : ITaskDetailViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }


        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand AbortCommand { get; set; }

        public TaskDetailViewModel()
        {
            Title = "Das ist ein Test";
            Description = "Laaaaanger Text mitadkflaskfjasdkj aksjfasjfklja klajfölasfdjasdfj maksjfasfkljask kaksjfasjfkajsfkl";
        }
    }
}
