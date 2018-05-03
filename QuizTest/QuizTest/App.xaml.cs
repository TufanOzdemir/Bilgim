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
        AnswerService answerService;
        public App()
        {
            questionService = new QuestionService();
            answerService = new AnswerService();
            InitializeComponent();
            ClearDatabase();
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
                    Description = "Aşağıdakilerden hangisi yukarıdadır?",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Tren",IsCorrect = false},
                    new Models.Answer(){Description = "Minibüs",IsCorrect = false},
                    new Models.Answer(){Description = "Yürüyen Uçak",IsCorrect = false},
                    new Models.Answer(){Description = "Gemi",IsCorrect = true},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Aşağıdakilerden hangisi bir Star Wars karakteri değildir?",
                    Difficult = Models.QuestionDifficult.Medium,
                    Time = 45
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Han Solo",IsCorrect = false},
                    new Models.Answer(){Description = "Padme",IsCorrect = false},
                    new Models.Answer(){Description = "Palpatin",IsCorrect = false},
                    new Models.Answer(){Description = "Alexandre",IsCorrect = true},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Aşağıdakilerden hangisi uzun ömrün simgesidir?",
                    Difficult = Models.QuestionDifficult.Hard,
                    Time = 60
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Papatya",IsCorrect = false},
                    new Models.Answer(){Description = "Bıcağa Sarılmış Yılan",IsCorrect = false},
                    new Models.Answer(){Description = "Lotus Çiçeği",IsCorrect = true},
                    new Models.Answer(){Description = "Mediterian Suyu",IsCorrect = false},
                }
            });
        }

        public void ClearDatabase()
        {
            questionService.DeleteAll();
            answerService.DeleteAll();
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
