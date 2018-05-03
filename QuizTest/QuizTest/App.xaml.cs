using System;
using System.Collections.Generic;
using QuizTest.Services;
using QuizTest.Views;
using Xamarin.Forms;

namespace QuizTest
{
    public partial class App : Application
    {
        QuestionService questionService;
        public App()
        {
            questionService = new QuestionService();
            InitializeComponent();
            if (questionService.GetAll().Count == 0)
            {
                FirstInitialize();
            }
            MainPage = new MainPage(this);
        }

        private void FirstInitialize()
        {

            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Deneme",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30,
                    ID = 1
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Ahahaha",IsCorrect = true,QuestionID = 1,ID = 1 },
                    new Models.Answer(){Description = "Zuhaha",IsCorrect = false,QuestionID = 1,ID = 1 },
                    new Models.Answer(){Description = "Puhaha",IsCorrect = false,QuestionID = 1,ID = 1 },
                    new Models.Answer(){Description = "Tuhaha",IsCorrect = false,QuestionID = 1,ID = 1 },
                }
            });
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
