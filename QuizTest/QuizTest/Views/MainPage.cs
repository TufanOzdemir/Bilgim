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
        Button _button;
        GameService _gameService;
        App app;
        public MainPage(App app)
        {
            this.app = app;
            BackgroundColor = App.CokKoyuTonRenk;
            _gameService = new GameService();
            ComponentLoad();
        }

        private void ComponentLoad()
        {
            StackLayout sl = new StackLayout() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
            _button = new Button { Text = "Başla", BackgroundColor = App.KoyuTonRenk, FontSize = 20, TextColor = App.AcikTonRenk, WidthRequest = 200, HeightRequest = 200, CornerRadius = 100, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, Command = new Command(this.StartGame) };
            sl.Children.Add(_button);
            Content = sl;
        }

        private void StartGame(object obj)
        {
            Game game = _gameService.StartNewGame();
            var width = Application.Current.MainPage.Width;
            var storyboard = new Animation();
            var rotation = new Animation(callback: d => _button.Rotation = d,
                                          start: _button.Rotation,
                                          end: _button.Rotation + 360,
                                          easing: Easing.SpringOut);


            var exitRight = new Animation(callback: d => _button.TranslationX = d,
                                           start: 0,
                                           end: width,
                                           easing: Easing.SpringIn);

            var enterLeft = new Animation(callback: d => _button.TranslationX = d,
                                           start: -width,
                                           end: 0,
                                           easing: Easing.BounceOut);
            storyboard.Add(0, 1, rotation);
            storyboard.Add(0, 0.5, exitRight);
            storyboard.Commit(_button, "Loop", length: 1400);
            app.ChangePage(new GamePage(game, app) { BackgroundColor = App.CokKoyuTonRenk });
        }
    }
}
