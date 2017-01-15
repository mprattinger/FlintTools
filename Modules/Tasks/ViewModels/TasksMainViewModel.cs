using FlintTools.Contracts.Infrastructure;
using FlintTools.Contracts.Models;
using FlintTools.Contracts.ServiceContracts;
using FlintTools.Contracts.ViewModels;
using Prism.Commands;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Tasks.ViewModels
{
    public class TasksMainViewModel : ViewModelBase
    {
        private ITasksService _tasksService;
        private IRegionManager _regionManager;

        private ObservableCollection<TaskItem> _tasks;
        public ObservableCollection<TaskItem> Tasks
        {
            get { return _tasks; }
            set
            {
                SetProperty(ref _tasks, value);
            }
        }

        private TaskItem _currentTask;
        public TaskItem CurrentTask
        {
            get { return _currentTask; }
            set
            {
                SetProperty(ref _currentTask, value);
            }
        }

        public DelegateCommand NewTask { get; set; }
        public DelegateCommand DeleteTask { get; set; }

        public TasksMainViewModel(ITasksService tasksService, IRegionManager regionManager)
        {
            _tasksService = tasksService;
            _regionManager = regionManager;

            NewTask = new DelegateCommand(() =>
            {
                //var task = new TaskItem { Title = "Neu 01", Description = "Ein neuer Task wird angelegt!" };
                //await _tasksService.AddTask(task);
                //Loaded();

                _regionManager.RequestNavigate(RegionNames.MainContentRegion, "TaskDetailView");

            });
        }

        public override async void Loaded()
        {
            base.Loaded();

            IsBusy = true;
            Tasks = new ObservableCollection<TaskItem>(await _tasksService.GetAllTasks());
            IsBusy = false;
        }
    }
}
