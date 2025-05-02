using System.Windows;
using Quiz.ViewModels;

namespace Quiz
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // utworzenie obiektu odpowiedzialnego za nawigację
            var navigationService = new Quiz.Services.NavigationService();

            // utworzenie modelu widoku dla widoku startowego
            var homeViewModel = new CreateQuizViewModel();
            //navigationService.NavigateTo<HomeViewModel>();
            navigationService.NavigateTo(homeViewModel);

            var mainWindow = new MainWindow
            {
                DataContext = new MainViewModel(navigationService)
            };

            mainWindow.Show();
        }
    }
}
