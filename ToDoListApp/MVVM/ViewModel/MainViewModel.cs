using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using ToDoListApp.MVVM.Model;

namespace ToDoListApp.MVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private TaskModel _selectedTask;
        private INavigation _navigation;  

        public ObservableCollection<TaskModel>Tasks{ get; set; }=new();

        public TaskModel SelectedTask
        {
            get=>_selectedTask;
            set
            {
                if(_selectedTask != value)
                {
                    _selectedTask = value;
                    OnPropertyChanged(nameof(SelectedTask));
                }
            }
        }

        public ICommand AddTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }
        public ICommand EditTaskCommand { get; }

        public MainViewModel(INavigation navigation) 
        {
            _navigation = navigation; 
            AddTaskCommand = new Command(AddTask);
            DeleteTaskCommand = new Command<TaskModel>(DeleteTask);
            EditTaskCommand = new Command(EditTask);

            Tasks.Add(new TaskModel { Name = "Limpiar la cocina", IsCompleted = false });
            Tasks.Add(new TaskModel { Name = "Hacer la compra", IsCompleted = false });
            Tasks.Add(new TaskModel { Name = "Pasear al perro", IsCompleted = false });
        }

        private void AddTask()
        {
            Tasks.Add(new TaskModel{ Name = "Nueva Tarea", IsCompleted = false });
        }

        private void DeleteTask(TaskModel task)
        {
            if(task != null && Tasks.Contains(task))
                Tasks.Remove(task);
        }

        private async void EditTask()  
        {
            if(SelectedTask != null)
            {
                int i = Tasks.IndexOf(SelectedTask);
                if (i >= 0)
                {
                    Tasks[i] = SelectedTask;
                    OnPropertyChanged(nameof(Tasks));
                    await _navigation.PopAsync();  
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
