using ToDoListApp.View;

namespace ToDoListApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPageView());
        }
    }
}
