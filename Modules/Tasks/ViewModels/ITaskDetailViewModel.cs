using Prism.Commands;

namespace Tasks.ViewModels
{
    public interface ITaskDetailViewModel
    {
        DelegateCommand AbortCommand { get; set; }
        string Description { get; set; }
        DelegateCommand SaveCommand { get; set; }
        string Title { get; set; }
    }
}