using System.Windows.Input;
using Quiz.Commands;
using Quiz.Services;

namespace Quiz.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;

        // aktualny model widoku
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set { _currentViewModel = value; OnPropertyChanged("CurrentViewModel"); }
        }


        // polecenia zmiany modelu widoku
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateSecondCommand { get; }


        // kondtruktor
        public MainViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.SetNavigator(vm => CurrentViewModel = vm);

            // tworzymy obiekty modelu widoku
            ViewModelBase hvm = new CreateQuizViewModel();
            ViewModelBase svm = new SolveQuizViewModel();

            // utworzenie obiektów typu RelayCommand,
            // polecenia mają za zadanie zmienić aktualny model widoku
            // polecenia zawsze można wykonać
            // jeśli parametr nie jest wykorzystywany w metodzie, wówczas w funkcji
            // lambda można wpisać _ zamiast nazwy parametru
            NavigateHomeCommand = new RelayCommand(_ => _navigationService.NavigateTo(hvm), _ => true);
            NavigateSecondCommand = new RelayCommand(_ => _navigationService.NavigateTo(svm), _ => true);

            CurrentViewModel = hvm;
        }
    }
}
