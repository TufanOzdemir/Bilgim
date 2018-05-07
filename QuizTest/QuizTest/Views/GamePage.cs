using ProgressRingControl.Forms.Plugin;
using QuizTest.Constant;
using QuizTest.Helper;
using QuizTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        Grid jokerGrid;
        MyTimer mainTimer;
        MyTimer otherTimer;
        int questionNumber;

        public GamePage(Game game, App app)
        {
            BackgroundColor = App.CokKoyuTonRenk;
            this.app = app;
            _game = game;
            question = _game.CurrentQuestionAnswerViewModel().Question;
            questionNumber = game.CurrentQuestionNumber + 1;
            Timer(question.Time);
            ComponentLoad();
            //this.ScaleTo(2, 1000, Easing.SpringIn);
            //this.ScaleTo(1, 1000, Easing.SpringOut);
        }

        private void ComponentLoad()
        {
            ScrollView sw = new ScrollView();
            StackLayout mainStack = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
            StackLayout bottomSl = new StackLayout() { VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.EndAndExpand, Padding = 10 };

            Frame frame = new Frame() { HasShadow = true, BackgroundColor = App.AcikTonRenk };
            frame.Content = new Label() { Text = questionNumber + " - " + question.Description, TextColor = App.KoyuTonRenk, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center };

            _btnTime = new Button() { Text = question.Time.ToString(), FontSize = 25, BackgroundColor = App.KoyuTonRenk, TextColor = App.AcikTonRenk, WidthRequest = 180, HeightRequest = 180, CornerRadius = 90, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, IsEnabled = false };

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
                }
            };

            jokerGrid = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(50, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(50, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(20, GridUnitType.Star) }
                }
            };

            Button j1 = new Button() { Text = "%50", BackgroundColor = App.KoyuTonRenk, TextColor = App.AcikTonRenk, IsVisible = !_game.IsPercent50JokerUsed, Margin = new Thickness(300, 0, 0, 0), WidthRequest = 40, HeightRequest = 40, CornerRadius = 20 };
            Button j2 = new Button() { Text = "2x", BackgroundColor = App.KoyuTonRenk, TextColor = App.AcikTonRenk, IsVisible = !_game.IsDoubleAnswerJokerUsed, Margin = new Thickness(300, 0, 0, 0), WidthRequest = 40, HeightRequest = 40, CornerRadius = 20 };

            Button b1 = new Button() { Text = "A) " + _game.CurrentQuestionAnswerViewModel().AnswerList[0].Description, ClassId = _game.CurrentQuestionAnswerViewModel().AnswerList[0].IsCorrect.ToString(), BackgroundColor = App.AcikTonRenk, TextColor = App.KoyuTonRenk, FontSize = 10 };
            Button b2 = new Button() { Text = "B) " + _game.CurrentQuestionAnswerViewModel().AnswerList[1].Description, ClassId = _game.CurrentQuestionAnswerViewModel().AnswerList[1].IsCorrect.ToString(), BackgroundColor = App.AcikTonRenk, TextColor = App.KoyuTonRenk, FontSize = 10 };
            Button b3 = new Button() { Text = "C) " + _game.CurrentQuestionAnswerViewModel().AnswerList[2].Description, ClassId = _game.CurrentQuestionAnswerViewModel().AnswerList[2].IsCorrect.ToString(), BackgroundColor = App.AcikTonRenk, TextColor = App.KoyuTonRenk, FontSize = 10 };
            Button b4 = new Button() { Text = "D) " + _game.CurrentQuestionAnswerViewModel().AnswerList[3].Description, ClassId = _game.CurrentQuestionAnswerViewModel().AnswerList[3].IsCorrect.ToString(), BackgroundColor = App.AcikTonRenk, TextColor = App.KoyuTonRenk, FontSize = 10 };

            j1.Clicked += Percent50JokerUse;
            j2.Clicked += DoubleJokerUse;

            b1.Clicked += CheckAnswerQuestion;
            b2.Clicked += CheckAnswerQuestion;
            b3.Clicked += CheckAnswerQuestion;
            b4.Clicked += CheckAnswerQuestion;

            answerGrid.Children.Add(b1, 0, 0);
            answerGrid.Children.Add(b2, 1, 0);
            answerGrid.Children.Add(b3, 0, 1);
            answerGrid.Children.Add(b4, 1, 1);

            jokerGrid.Children.Add(j1, 0, 0);
            jokerGrid.Children.Add(j2, 0, 1);

            bottomSl.Children.Add(frame);
            bottomSl.Children.Add(answerGrid);

            mainStack.Children.Add(jokerGrid);
            mainStack.Children.Add(_btnTime);
            mainStack.Children.Add(bottomSl);
            sw.Content = mainStack;
            Content = sw;
        }

        private void DoubleJokerUse(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            _game.IsDoubleAnswerJokerUsing = true;
            btn.IsVisible = false;
        }

        private void Percent50JokerUse(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            _game.IsPercent50JokerUsed = true;
            answerGrid.Children.Where(i => i.ClassId.Equals("False")).ToList().PickRandom(2).ToList().ForEach(i => { i.IsVisible = false; });
            btn.IsVisible = false;
        }

        private void CheckAnswerQuestion(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.ClassId.Equals("True"))
            {
                GameOver(button, true);
            }
            else
            {
                if (_game.IsDoubleAnswerJokerUsed)
                {
                    GameOver(button, false);
                }
                else if (_game.IsDoubleAnswerJokerUsing)
                {
                    button.BackgroundColor = Color.Red;
                }
                else
                {
                    GameOver(button, false);
                }
            }

            _game.IsDoubleAnswerJokerUsed = _game.IsDoubleAnswerJokerUsing;
        }

        private void GameOver(Button button, bool status)
        {
            if (status)
            {
                button.BackgroundColor = Color.Green;
                _game.ScoreAdd(question.Difficult);
            }
            else
            {
                button.BackgroundColor = Color.Red;
                _game.GameStatus = false;
            }
            app.StopSound();
            ReGenerateButton();
            NextPageTimer(0.5f, status);
        }

        private void ReGenerateButton()
        {
            foreach (Button item in answerGrid.Children)
            {
                if (item.ClassId.Equals("True"))
                {
                    item.BackgroundColor = Color.Green;
                }
                item.IsEnabled = false;
            }
        }

        private void NextPageTimer(double time, bool correct)
        {
            if (correct)
            {
                otherTimer = new MyTimer(TimeSpan.FromSeconds(1), NextScreen, false);
            }
            else
            {
                otherTimer = new MyTimer(TimeSpan.FromSeconds(1), LostScreen, false);
            }
            mainTimer.Stop();
            otherTimer.StartTime(time);
        }

        private void Timer(double time)
        {
            mainTimer = new MyTimer(TimeSpan.FromSeconds(1), TimeOut, false);
            mainTimer.StartTime(question.Time);
            app.PlaySound((int)SoundEnum.TimeSound);
        }

        private void TimeOut()
        {
            if (mainTimer.timer <= 0)
            {
                app.StopSound();
                DisplayAlert("Üzgünüz..", $"Soruyu cevaplamanız için ayrılan süre bitti ! Kaybettiniz. Skorunuz : {_game.Point}", "Tamam");
                _game.IsTimeOut = true;
                RedirectToMainPage();
            }
            else
            {
                _btnTime.Text = mainTimer.timer.ToString();
            }
        }

        private void LostScreen()
        {
            if (otherTimer.timer <= 0)
            {
                DisplayAlert("Üzgünüz", $"Kaybettiniz. Skorunuz : {_game.Point}", "Tamam");
                RedirectToMainPage();
            }
        }

        private void NextScreen()
        {
            if (otherTimer.timer <= 0)
            {
                _game.CurrentQuestionNumber++;
                _game.NextTour();
                if (_game.GameStatus)
                {
                    app.ChangePage(new GamePage(_game, app) { BackgroundColor = App.CokKoyuTonRenk });
                }
                else
                {
                    WinScreenOpen();
                }
            }
        }

        private void RedirectToMainPage()
        {
            app.ChangePage(new MainPage(app));
        }

        private void WinScreenOpen()
        {
            app.ChangePage(new WinPage(app, _game));
        }
    }
}
