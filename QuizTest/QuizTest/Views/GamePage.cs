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
        Grid answerGrid;

        public GamePage(Game game, App app)
        {
            this.app = app;
            _game = game;
            question = _game.CurrentQuestionAnswerViewModel().Question;
            _btnTime = new Button() { Text = question.Time.ToString(), WidthRequest = 140, HeightRequest = 140, CornerRadius = 70, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, IsEnabled = false };
            Timer(question.Time);
            ComponentLoad();
        }

        private void WinScreenOpen()
        {
            app.ChangePage(new WinPage(app, _game));
        }

        private void ComponentLoad()
        {
            StackLayout sl = new StackLayout() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Fill, Padding = 5 };

            var progressRing = new ProgressRing { RingThickness = 20, Progress = 0.5f, BackgroundColor = Color.Black, IsEnabled = true, IsVisible = true, RingBaseColor = Color.Red, RingProgressColor = Color.Green, AnimatedProgress = 1, AnimationEasing = Easing.Linear };
            sl.Children.Add(progressRing);
            StackLayout bottomSl = new StackLayout() { VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.EndAndExpand, Padding = 10 };

            Frame frame = new Frame() { HasShadow = true };
            frame.Content = new Label() { Text = question.Description };

            answerGrid = new Grid()
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

            Button b1 = new Button() { Text = _game.CurrentQuestionAnswerViewModel().AnswerList[0].Description, ClassId = _game.CurrentQuestionAnswerViewModel().AnswerList[0].IsCorrect.ToString() };
            Button b2 = new Button() { Text = _game.CurrentQuestionAnswerViewModel().AnswerList[1].Description, ClassId = _game.CurrentQuestionAnswerViewModel().AnswerList[1].IsCorrect.ToString() };
            Button b3 = new Button() { Text = _game.CurrentQuestionAnswerViewModel().AnswerList[2].Description, ClassId = _game.CurrentQuestionAnswerViewModel().AnswerList[2].IsCorrect.ToString() };
            Button b4 = new Button() { Text = _game.CurrentQuestionAnswerViewModel().AnswerList[3].Description, ClassId = _game.CurrentQuestionAnswerViewModel().AnswerList[3].IsCorrect.ToString() };

            b1.Clicked += CheckAnswerQuestion;
            b2.Clicked += CheckAnswerQuestion;
            b3.Clicked += CheckAnswerQuestion;
            b4.Clicked += CheckAnswerQuestion;

            answerGrid.Children.Add(b1, 0, 0);
            answerGrid.Children.Add(b2, 1, 0);
            answerGrid.Children.Add(b3, 0, 1);
            answerGrid.Children.Add(b4, 1, 1);

            bottomSl.Children.Add(frame);
            bottomSl.Children.Add(answerGrid);

            sl.Children.Add(_btnTime);
            sl.Children.Add(bottomSl);

            Content = sl;
        }

        private void CheckAnswerQuestion(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            _game.IsGamePaused = true;
            if (button.ClassId.Equals("True"))
            {
                button.BackgroundColor = Color.Green;
                _game.ScoreAdd(question.Difficult);
                NextPageTimer(3, true);
            }
            else
            {
                button.BackgroundColor = Color.Red;
                _game.GameStatus = false;
                NextPageTimer(3, false);
            }
            foreach (Button item in answerGrid.Children)
            {
                if (item.ClassId.Equals("True"))
                {
                    item.BackgroundColor = Color.Green;
                }
                item.IsEnabled = false;
            }
        }

        private void Timer(double time)
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (!_game.IsGamePaused)
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
                }
                return true;
            });
        }

        private void NextPageTimer(double time, bool correct)
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                time -= 1;
                if (time == 0.00)
                {
                    if (correct)
                    {
                        _game.IsGamePaused = false;
                        _game.CurrentQuestionNumber++;
                        _game.NextTour();
                        if (_game.GameStatus)
                        {
                            app.ChangePage(new GamePage(_game, app));
                        }
                        else
                        {
                            WinScreenOpen();
                        }
                    }
                    else
                    {
                        DisplayAlert("Üzgünüz..", $"Kaybettiniz. Skorunuz : {_game.Point}", "Tamam");
                        RedirectToMainPage();
                    }
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
