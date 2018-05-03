using ProgressRingControl.Forms.Plugin;
using QuizTest.Constant;
using QuizTest.Models;
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
        Question question;
        public GamePage(Game game, App app)
        {
            this.app = app;
            game.CurrentQuestionNumber = 0;
            _btnTime = new Button() { WidthRequest = 140, HeightRequest = 140, CornerRadius = 70, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, IsEnabled = false };
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
            question = game.QuestionsWithAnswers[game.CurrentQuestionNumber].Question;
            Timer(game.QuestionsWithAnswers[game.CurrentQuestionNumber].Question.Time);
            ComponentLoad();
        }

        private void ComponentLoad()
        {
            StackLayout sl = new StackLayout() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Fill, Padding = 5 };
           
            var progressRing = new ProgressRing { RingThickness = 20, Progress = 0.5f , BackgroundColor = Color.Black, IsEnabled = true , IsVisible = true, RingBaseColor = Color.Red, RingProgressColor = Color.Green, AnimatedProgress = 1 , AnimationEasing = Easing.Linear};
            sl.Children.Add(progressRing);
            StackLayout bottomSl = new StackLayout() { VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.EndAndExpand, Padding = 10 };

            Frame frame = new Frame() { HasShadow = true };
            frame.Content = new Label() { Text = question.Description };

            Grid answerGrid = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(50, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(50, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(50, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(50, GridUnitType.Star) }
                },
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center
            };
            answerGrid.Children.Add(new Button() { Text = _game.QuestionsWithAnswers[_game.CurrentQuestionNumber].AnswerList[0].Description }, 0, 0);
            answerGrid.Children.Add(new Button() { Text = _game.QuestionsWithAnswers[_game.CurrentQuestionNumber].AnswerList[1].Description }, 1, 0);
            answerGrid.Children.Add(new Button() { Text = _game.QuestionsWithAnswers[_game.CurrentQuestionNumber].AnswerList[2].Description }, 0, 1);
            answerGrid.Children.Add(new Button() { Text = _game.QuestionsWithAnswers[_game.CurrentQuestionNumber].AnswerList[3].Description }, 1, 1);
            sl.Children.Add(_btnTime);
            bottomSl.Children.Add(frame);
            bottomSl.Children.Add(answerGrid);
            sl.Children.Add(bottomSl);
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
