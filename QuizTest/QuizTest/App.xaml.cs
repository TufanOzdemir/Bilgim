using System;
using QuizTest.Services;
using QuizTest.Views;
using Xamarin.Forms;

namespace QuizTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage(this);
        }

        public void ChangePage(ContentPage page)
        {
            MainPage = page;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
