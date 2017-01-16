using FlintTools.Contracts.ServiceContracts;
using FlintTools.DAL.Services.Tasks;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;
using Tasks.Views;

namespace Tasks
{
    public class TasksModule : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public TasksModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<Object, TaskDetailView>("TaskDetailView");

            _container.RegisterInstance<ITasksService>(new TasksService());

            _regionManager.RegisterViewWithRegion("MainRegion", typeof(TasksMainView));
        }
    }
}
