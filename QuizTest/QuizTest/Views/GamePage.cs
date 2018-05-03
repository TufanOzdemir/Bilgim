﻿using ProgressRingControl.Forms.Plugin;
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
        MyTimer mainTimer;
        MyTimer otherTimer;

        public GamePage(Game game, App app)
        {
            BackgroundColor = App.CokKoyuTonRenk;
            this.app = app;
            _game = game;
            question = _game.CurrentQuestionAnswerViewModel().Question;
            Timer(question.Time);
            ComponentLoad();
        }

        private void ComponentLoad()
        {
            Frame MainFrame = new Frame();
            StackLayout sl = new StackLayout() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Fill, Padding = 5 };
            StackLayout bottomSl = new StackLayout() { VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.EndAndExpand, Padding = 10 };

            Frame frame = new Frame() { HasShadow = true, BackgroundColor = App.HafifKoyuTonRenk };
            frame.Content = new Label() { Text = question.Description, TextColor = App.AcikTonRenk };

            _btnTime = new Button() { Text = question.Time.ToString(), FontSize = 15, BackgroundColor = App.KoyuTonRenk, TextColor = App.AcikTonRenk, WidthRequest = 140, HeightRequest = 140, CornerRadius = 70, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };

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

            Button b1 = new Button() { Text = _game.CurrentQuestionAnswerViewModel().AnswerList[0].Description, ClassId = _game.CurrentQuestionAnswerViewModel().AnswerList[0].IsCorrect.ToString(), BackgroundColor = App.HafifKoyuTonRenk, TextColor = BackgroundColor = App.KoyuTonRenk };
            Button b2 = new Button() { Text = _game.CurrentQuestionAnswerViewModel().AnswerList[1].Description, ClassId = _game.CurrentQuestionAnswerViewModel().AnswerList[1].IsCorrect.ToString(), BackgroundColor = App.HafifKoyuTonRenk, TextColor = BackgroundColor = App.KoyuTonRenk };
            Button b3 = new Button() { Text = _game.CurrentQuestionAnswerViewModel().AnswerList[2].Description, ClassId = _game.CurrentQuestionAnswerViewModel().AnswerList[2].IsCorrect.ToString(), BackgroundColor = App.HafifKoyuTonRenk, TextColor = BackgroundColor = App.KoyuTonRenk };
            Button b4 = new Button() { Text = _game.CurrentQuestionAnswerViewModel().AnswerList[3].Description, ClassId = _game.CurrentQuestionAnswerViewModel().AnswerList[3].IsCorrect.ToString(), BackgroundColor = App.HafifKoyuTonRenk, TextColor = BackgroundColor = App.KoyuTonRenk };

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
            
            MainFrame.Content = sl;

            sl.Children.Add(_btnTime);
            sl.Children.Add(bottomSl);

            Content = MainFrame;
        }

        private void CheckAnswerQuestion(object sender, EventArgs e)
        {
            Button button = (Button)sender;
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
        }

        private void TimeOut()
        {
            if (mainTimer.timer <= 0)
            {
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
