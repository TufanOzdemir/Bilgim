using QuizTest.Constant;
using QuizTest.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QuizTest.Views
{
    public class MainPage : ContentPage
    {

        GameService _gameService;
        App app;
        public MainPage(App app)
        {
            this.app = app;
            _gameService = new GameService();
            ComponentLoad();
        }

        private void ComponentLoad()
        {
            StackLayout sl = new StackLayout();
            sl.Children.Add(new Button { Text = "Başla", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, Command = new Command(this.StartGame) });
            Content = sl;
        }

        private void StartGame(object obj)
        {
            Game game = _gameService.StartNewGame();
            app.ChangePage(new GamePage(game, app));
        }
    }
}
