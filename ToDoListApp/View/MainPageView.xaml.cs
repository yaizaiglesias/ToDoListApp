using ToDoListApp.ViewModel;
using ToDoListApp.View;

namespace ToDoListApp.View;

public partial class MainPageView : ContentPage
{
    public MainPageView()
    {
        InitializeComponent();
    }

    private async void OnTaskSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Model.TaskModel selectedTask)
        {
            if (BindingContext is MainViewModel viewModel)
            {
                viewModel.SelectedTask = selectedTask;
                var taskDetailPage = new TaskDetail
                {
                    BindingContext = viewModel
                };
                await Navigation.PushAsync(taskDetailPage);
            }
        }
        
        if (sender is CollectionView collectionView)
        {
            collectionView.SelectedItem = null;
        }
    }
}

