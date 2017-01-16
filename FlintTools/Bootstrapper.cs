using FlintTools.DAL;
using Prism.Unity;
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
        }

        protected override void ConfigureModuleCatalog()
        {
            var catalog = ModuleCatalog as Prism.Modularity.ModuleCatalog;
            catalog.AddModule(typeof(TasksModule));
            catalog.AddModule(typeof(DALModule));

        }
    }
}
