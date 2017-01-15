using FlintTools.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tasks.Views
{
    /// <summary>
    /// Interaction logic for TasksMainView.xaml
    /// </summary>
    public partial class TasksMainView : UserControl
    {
        public TasksMainView()
        {
            InitializeComponent();

            this.Loaded += (s, e) => {
                var vm = (ViewModelBase)this.DataContext;

                vm.Loaded();
            };
        }
    }
}
