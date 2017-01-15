using Prism.Modularity;
using Prism.Regions;
using System;
using Tasks.Views;

namespace Tasks
{
    public class TasksModule : IModule
    {
        IRegionManager _regionManager;

        public TasksModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(TasksMainView));
        }
    }
}
