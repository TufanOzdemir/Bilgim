using QuizTest.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace QuizTest.Views
{
    public class GamePage : ContentPage
    {
        Button _btnTime;
        Game _game;
        App app;
        public GamePage(Game game,App app)
        {
            this.app = app;
            game.CurrentQuestionNumber = 0;
            _btnTime = new Button() { WidthRequest = 40, HeightRequest = 40, CornerRadius = 80};
            _game = game;
            game.QuestionsWithAnswers.Add(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Deneme",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30,
                    ID = 1
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Ahaha",IsCorrect = true,QuestionID = 1,Title = "A",ID = 1 },
                    new Models.Answer(){Description = "Zuhaha",IsCorrect = false,QuestionID = 1,Title = "B",ID = 1 },
                    new Models.Answer(){Description = "Puhaha",IsCorrect = false,QuestionID = 1,Title = "C",ID = 1 },
                    new Models.Answer(){Description = "Tuhaha",IsCorrect = false,QuestionID = 1,Title = "D",ID = 1 },
                }
            });
            Timer(game.QuestionsWithAnswers[game.CurrentQuestionNumber].Question.Time);
            ComponentLoad();
        }

        private void ComponentLoad()
        {
            StackLayout sl = new StackLayout() { VerticalOptions = LayoutOptions.CenterAndExpand };

            sl.Children.Add(_btnTime);
            Content = sl;
        }

        private void Timer(double time)
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                time -= 1;
                _btnTime.Text = String.Format("{0}", time);
                if (time == 0.00)
                {
                    DisplayAlert("Üzgünüz..", $"Soruyu cevaplamanız için ayrılan süre bitti ! Kaybettiniz. Skorunuz : {_game.Point}", "Tamam");
                    _game.IsTimeOut = true;
                    RedirectToMainPage();
                    return false;
                }

                return true;
            });
        }

        private void RedirectToMainPage()
        {
            app.ChangePage(new MainPage(app));
        }
    }
}
