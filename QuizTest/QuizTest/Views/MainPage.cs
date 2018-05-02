using QuizTest.Constant;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QuizTest.Views
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            ComponentLoad();
        }

        private void ComponentLoad()
        {
            StackLayout sl = new StackLayout();
            sl.Children.Add(new Button { Text = "Başla", VerticalOptions = LayoutOptions.Center,HorizontalOptions = LayoutOptions.Center,Command = new Command(this.StartGame) });
            Content = sl;
        }

        private async void StartGame(object obj)
        {
            Game game = new Game();
            await Navigation.PushAsync(new GamePage(1,game));
        }
    }
}
