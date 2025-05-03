using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Quiz.Models
{
    public class Question : INotifyPropertyChanged
    {
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }

        public ObservableCollection<AnswerOption> Answers { get; set; }

        public Question()
        {
            Answers = new ObservableCollection<AnswerOption>
            {
                new AnswerOption(),
                new AnswerOption(),
                new AnswerOption(),
                new AnswerOption()
            };


        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class AnswerOption
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public AnswerOption()
        {
            Text = string.Empty;
            IsCorrect = false;
        }
    }
}
