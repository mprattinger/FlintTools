using FlintTools.Contracts.Infrastructure;
using FlintTools.Contracts.Models;
using FlintTools.Contracts.ServiceContracts;
using FlintTools.Contracts.ViewModels;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Tasks.Models;

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

        private ObservableCollection<TaskStatusModel> _status;
        public ObservableCollection<TaskStatusModel> Status
        {
            get { return _status; }
            set
            {
                SetProperty(ref _status, value);
            }
        }

        private TaskStatusModel _currentStatus;
        public TaskStatusModel CurrentStatus
        {
            get { return _currentStatus; }
            set
            {
                SetProperty(ref _currentStatus, value);
                statusChanged();

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
                var par = new NavigationParameters();
                par.Add("ID", null);

                _regionManager.RequestNavigate(RegionNames.MainContentRegion, "TaskDetailView", par);
            });

            Status = new ObservableCollection<TaskStatusModel>(TaskExts.TaskStatusValues(true));

        }

        public override void Loaded()
        {
            base.Loaded();

            loadData();
        }

        private async void loadData()
        {
            IsBusy = true;
            Tasks = new ObservableCollection<TaskItem>(await _tasksService.GetAllTasks());
            IsBusy = false;
        }

        private void statusChanged()
        {

        }
    }
}
