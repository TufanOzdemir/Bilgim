using QuizTest.Constant;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QuizTest.Views
{
    public class WinPage : ContentPage
    {
        Game _game;
        App app;
        public WinPage(App app, Game game)
        {
            _game = game;
            this.app = app;
            ComponentLoad();
        }

        private void ComponentLoad()
        {
            Content = new StackLayout()
            {
                Children =
                {
                    new Label()
                    {
                        Text = $"Puanınız : {_game.Point} \n Tebrikler Kazandınız"
                    },
                    new Button()
                    {
                        Text = "Ana Menüye Dön",
                        Command = new Command(this.MainMenu)
                    }
                }
            };
        }

        private void MainMenu(object obj)
        {
            app.ChangePage(new MainPage(app));
        }
    }
}
