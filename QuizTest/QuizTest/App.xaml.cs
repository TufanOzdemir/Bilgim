using System;
using System.Collections.Generic;
using QuizTest.Services;
using QuizTest.Views;
using Xamarin.Forms;

namespace QuizTest
{
    public partial class App : Application
    {
        public static Color AcikTonRenk = Color.FromHex("#ecf0f1");
        public static Color HafifKoyuTonRenk = Color.FromHex("#3498db");
        public static Color KoyuTonRenk = Color.FromHex("#960FEE");
        public static Color CokKoyuTonRenk = Color.FromHex("#260742");

        QuestionService questionService;
        AnswerService answerService;
        public App()
        {
            questionService = new QuestionService();
            answerService = new AnswerService();
            InitializeComponent();
            //ClearDatabase();
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
                    Description = "Aşağıdakilerden hangisi bir prgramlama dili değildir?",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "C#",IsCorrect = false},
                    new Models.Answer(){Description = "Java",IsCorrect = false},
                    new Models.Answer(){Description = "Tizen",IsCorrect = true},
                    new Models.Answer(){Description = "Swift",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Oha lan ayı diye bağıran bir adamın o an ki duygusu nedir?",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Sinirli",IsCorrect = true},
                    new Models.Answer(){Description = "Gergin",IsCorrect = false},
                    new Models.Answer(){Description = "Sakin",IsCorrect = false},
                    new Models.Answer(){Description = "Mutsuz",IsCorrect = false},
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
                    Description = "Aşağıdakilerden hangisi outdoor sporlardandır?",
                    Difficult = Models.QuestionDifficult.Medium,
                    Time = 45
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Squash",IsCorrect = false},
                    new Models.Answer(){Description = "Rafting",IsCorrect = true},
                    new Models.Answer(){Description = "Bilardo",IsCorrect = false},
                    new Models.Answer(){Description = "Bowling",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Ankesörlü telefonda kullanılan jetonların rengi nedir?",
                    Difficult = Models.QuestionDifficult.Medium,
                    Time = 45
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Kırmızı",IsCorrect = false},
                    new Models.Answer(){Description = "Yeşil",IsCorrect = false},
                    new Models.Answer(){Description = "Sarı",IsCorrect = true},
                    new Models.Answer(){Description = "Mavi",IsCorrect = false},
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
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Hem kapı kolu hemde bahane anlamında kullanılan kelime hangisidir?",
                    Difficult = Models.QuestionDifficult.Hard,
                    Time = 60
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Kulp",IsCorrect = true},
                    new Models.Answer(){Description = "Tokmak",IsCorrect = false},
                    new Models.Answer(){Description = "Hokka",IsCorrect = false},
                    new Models.Answer(){Description = "Mandal",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Dilimize fransızcadan geçen ve bir tiyatroterimi ile bir tatlı ismi olarak kullanılan kelime hangisidir?",
                    Difficult = Models.QuestionDifficult.Hard,
                    Time = 60
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Turta",IsCorrect = false},
                    new Models.Answer(){Description = "Sufle",IsCorrect = true},
                    new Models.Answer(){Description = "Gofret",IsCorrect = false},
                    new Models.Answer(){Description = "Pafye",IsCorrect = false},
                }
            });
        }

        public void ClearDatabase()
        {
            questionService.DeleteAll();
            answerService.DeleteAll();
        }

        public void ChangePage(ContentPage contentPage)
        {
            MainPage = contentPage;
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
