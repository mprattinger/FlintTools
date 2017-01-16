using FlintTools.Contracts.Infrastructure;
using FlintTools.Contracts.Models;
using FlintTools.Contracts.ServiceContracts;
using FlintTools.Contracts.ViewModels;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Tasks.ViewModels
{
    public class TaskDetailViewModel : ViewModelBase, INavigationAware, ITaskDetailViewModel
    {
        private ITasksService _tasksService;
        private IRegionManager _regionManager;
        private bool _isDirty;
                                              
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                SetProperty(ref _description, value);
            }
        }

        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand AbortCommand { get; set; }

        public TaskDetailViewModel(ITasksService taskService, IRegionManager regionManager)
        {
            _tasksService = taskService;
            _regionManager = regionManager;

            AbortCommand = new DelegateCommand(() =>
            {
                if (_isDirty)
                {
                    //Do something
                }

                _regionManager.RequestNavigate(RegionNames.MainContentRegion, "TasksMainView");
            });

            SaveCommand = new DelegateCommand(async () =>
            {
                if (_isDirty)
                {
                    var res = await _tasksService.AddTask(new TaskItem { Title = Title, Description = Description });
                    if (!res)
                    {
                        //Todo Error-Handlung
                        return;
                    }
                }

                _regionManager.RequestNavigate(RegionNames.MainContentRegion, "TasksMainView");
            });
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Debug.WriteLine("Navigated To....");
        }

        protected override bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            _isDirty = true;

            return base.SetProperty<T>(ref storage, value, propertyName);
        }
    }
}
