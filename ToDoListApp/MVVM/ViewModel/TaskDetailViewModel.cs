using System.Windows.Input;
using ToDoListApp.MVVM.Model;

namespace ToDoListApp.MVVM.ViewModel
{
    public class TaskDetailViewModel
    {
        private readonly INavigation _navigation;
        private readonly MainViewModel _mainViewModel;  

        public TaskModel SelectedTask { get; set; }

        public ICommand SaveTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }

        public TaskDetailViewModel(INavigation navigation, MainViewModel mainViewModel, TaskModel task)
        {
            _navigation = navigation;
            _mainViewModel = mainViewModel;  
            SelectedTask = task;

            SaveTaskCommand = new Command(SaveTask);
            DeleteTaskCommand = new Command(DeleteTask);
        }

        private async void SaveTask()
        {
            if(_mainViewModel.Tasks.Contains(SelectedTask))
            {
                var index = _mainViewModel.Tasks.IndexOf(SelectedTask);
                _mainViewModel.Tasks[index] = SelectedTask;
            }
            else
            {
                _mainViewModel.Tasks.Add(SelectedTask);
            }
            await _navigation.PopAsync();
        }

        private async void DeleteTask()
        {
            if(_mainViewModel.Tasks.Contains(SelectedTask))
            {
                _mainViewModel.Tasks.Remove(SelectedTask);
            }
            await _navigation.PopAsync();
        }
    }
}
