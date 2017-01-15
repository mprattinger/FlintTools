using FlintTools.Contracts.ServiceContracts;
using FlintTools.DAL;
using FlintTools.DAL.Services.Tasks;
using Microsoft.Practices.Unity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tasks;

namespace FlintTools
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterInstance<ITasksService>(new TasksService());
        }

        protected override void ConfigureModuleCatalog()
        {
            var catalog = ModuleCatalog as Prism.Modularity.ModuleCatalog;
            catalog.AddModule(typeof(TasksModule));
            catalog.AddModule(typeof(DALModule));

        }
    }
}
