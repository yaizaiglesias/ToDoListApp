using ToDoListApp.MVVM.Model;
using ToDoListApp.MVVM.ViewModel;

namespace ToDoListApp.View
{
    public partial class TaskDetail : ContentPage
    {
        public TaskDetail(MainViewModel mainViewModel, TaskModel task)
        {
            InitializeComponent();
            BindingContext = new TaskDetailViewModel(Navigation, mainViewModel, task);
        }
    }
}
