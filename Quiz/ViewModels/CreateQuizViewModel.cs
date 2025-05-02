namespace Quiz.ViewModels
{
    public class CreateQuizViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Witamy w aplikacji!";

        private double _fontSize = 12.0;
        public double FontSize
        {
            get => _fontSize;
            set
            {
                if (_fontSize != value)
                {
                    _fontSize = value;
                    OnPropertyChanged("FontSize");
                }
            }
        }
    }
}
