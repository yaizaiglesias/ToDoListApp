using ToDoListApp.MVVM.Model;
using ToDoListApp.MVVM.ViewModel;

namespace ToDoListApp.View
{
    public partial class MainPageView : ContentPage
    {
        public MainViewModel _vm;

        public MainPageView()
        {
            InitializeComponent();
            _vm = new MainViewModel(Navigation);
            BindingContext = _vm;
        }

        private async void OnTaskSelected(object sender, SelectionChangedEventArgs e)
        {
            if(e.CurrentSelection.FirstOrDefault() is TaskModel selectedTask)
            {
                var taskDetailPage = new TaskDetail(_vm, selectedTask);
                await Navigation.PushAsync(taskDetailPage);
            }

            if(sender is CollectionView collectionView)
            {
                collectionView.SelectedItem = null;
            }
        }
    }
}
