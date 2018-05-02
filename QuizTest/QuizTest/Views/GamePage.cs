using QuizTest.Constant;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QuizTest.Views
{
    public class GamePage : ContentPage
    {
        Label _lblTime;
        Game game;
        public GamePage(int currentQuestion, Game game)
        {
            _lblTime = new Label();
            this.game = game;
            ComponentLoad();
        }

        private void ComponentLoad()
        {
            StackLayout sl = new StackLayout();
            sl.Children.Add(_lblTime);
            TimerStarterClicked();

            Content = sl;
        }

        private void Timer(double time)
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                time -= 1;
                _lblTime.Text = String.Format("{0}", time);
                if (time == 0.00)
                {
                    DisplayAlert("Süre Doldu", "Geri sayım süresi bitti!", "Tamam");
                    game.IsTimeOut = true;
                    Last();
                    return false;
                }

                return true;
            });
        }

        private void Last()
        {

        }

        private void TimerStarterClicked()
        {
            Timer(10);
        }
    }
}
