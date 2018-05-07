using QuizTest.Constant;
using QuizTest.Interface;
using QuizTest.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace QuizTest.Views
{
    public class MainPage : ContentPage
    {
        IAudio _audio;
        Button _button;
        GameService _gameService;
        App app;
        public MainPage(App app)
        {
            this.app = app;
            BackgroundColor = App.CokKoyuTonRenk;
            _gameService = new GameService();
            _audio = DependencyService.Get<IAudio>();
            ComponentLoad();
        }

        private void ComponentLoad()
        {
            StackLayout sl = new StackLayout() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
            _button = new Button { Text = "Başla", BackgroundColor = App.KoyuTonRenk, FontSize = 20, TextColor = App.AcikTonRenk, WidthRequest = 200, HeightRequest = 200, CornerRadius = 100, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, Command = new Command(this.StartGame) };
            sl.Children.Add(_button);
            Content = sl;
        }

        private async void StartGame(object obj)
        {
            _audio.PlayAudio((int)SoundEnum.WinSound);
            Game game = _gameService.StartNewGame();
            var width = Application.Current.MainPage.Width;
            var storyboard = new Animation();
            var animation = new Animation(callback: d => _button.Rotation = d,
                                 start: _button.Rotation,
                                 end: _button.Rotation + 360,
                                 easing: Easing.SpringOut);
            _button.Animate("Loop",animation,1,250,Easing.SpringOut);

           await _button.ScaleTo(2,1000,Easing.SpringIn);
           await _button.ScaleTo(1,1000,Easing.SpringOut);

            app.ChangePage(new GamePage(game, app) { BackgroundColor = App.CokKoyuTonRenk });
        }
    }
}
