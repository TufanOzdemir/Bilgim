﻿using QuizTest.Constant;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QuizTest.Views
{
    public class WinPage : ContentPage
    {
        #region Global Definitions
        Game _game;
        App app;
        #endregion

        //Yapılandırıcı üzerinden temel ayarlar yapılandırıldı.
        public WinPage(App app, Game game)
        {
            BackgroundColor = App.CokKoyuTonRenk;
            _game = game;
            this.app = app;
            ComponentLoad();
        }

        //Gerekli viewler yüklendi.
        private void ComponentLoad()
        {
            Content = new StackLayout()
            {
                Children =
                {
                    new Frame()
                    {
                        Content = new Label()
                        {
                            Text = $"Puanınız : {_game.Point} \nTebrikler Kazandınız",
                            TextColor = App.HafifKoyuTonRenk,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center
                        },
                        HasShadow = true,
                        BackgroundColor = App.KoyuTonRenk
                    },
                    new Button()
                    {
                        Text = "Ana Menüye Dön",
                        WidthRequest = 200,
                        HeightRequest = 200,
                        CornerRadius = 100,
                        BackgroundColor = App.KoyuTonRenk,
                        TextColor = App.AcikTonRenk,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        Command = new Command(this.MainMenu)
                    }
                },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = App.CokKoyuTonRenk
            };
        }

        //Menüye yönlendirme işlemi yapıldı.
        private void MainMenu(object obj)
        {
            app.ChangePage(new MainPage(app));
        }
    }
}
