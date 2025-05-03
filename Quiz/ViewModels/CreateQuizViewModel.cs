using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Quiz.Commands;
using Quiz.Models;

namespace Quiz.ViewModels
{
    public class CreateQuizViewModel : ViewModelBase
    {
        public ObservableCollection<Question> Questions { get; set; }
        private Question _selectedQuestion;
        public Question SelectedQuestion
        {
            get => _selectedQuestion;
            set
            {
                _selectedQuestion = value;
                OnPropertyChanged(nameof(SelectedQuestion));
            }
        }

        private string _newQuestionText;
        public string NewQuestionText
        {
            get => _newQuestionText;
            set
            {
                _newQuestionText = value;
                OnPropertyChanged(nameof(NewQuestionText));
            }
        }

        public ICommand AddQuestionCommand { get; }
        public ICommand RemoveQuestionCommand { get; }
        public ICommand SaveQuizCommand { get; }
        public ICommand EditQuestionCommand { get; }

        public CreateQuizViewModel()
        {
            Questions = new ObservableCollection<Question>()
            {
                new Question {Text = "bla bla "},
                new Question {Text = "bla bla 2"},
            };
            AddQuestionCommand = new RelayCommand(_ => AddQuestion(), _ => true);
            RemoveQuestionCommand = new RelayCommand(_ => RemoveQuestion(), _ => SelectedQuestion != null);
            SaveQuizCommand = new RelayCommand(_ => SaveQuiz(), _ => Questions.Count > 0);
            EditQuestionCommand = new RelayCommand(_ => EditQuestion(), _ => SelectedQuestion != null);
        }

        private void AddQuestion()
        {
            var newQuestion = new Question
            {
                Text = NewQuestionText
            };

            Questions.Add(newQuestion);
            SelectedQuestion = newQuestion;
            OnPropertyChanged(nameof(SelectedQuestion));
        }



        private void RemoveQuestion()
        {
            if (SelectedQuestion != null)
            {
                Questions.Remove(SelectedQuestion);
                SelectedQuestion = null;
                OnPropertyChanged(nameof(RemoveQuestionCommand)); // Upewnij się, że przycisk się odświeża
            }
        }

        private void SaveQuiz()
        {
            // Implement the logic to save the quiz
            // This could involve saving to a file or a database
        }

        private void EditQuestion()
        {
            // Implement the logic to edit the selected question
            // This could involve opening a dialog or a new view for editing
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
