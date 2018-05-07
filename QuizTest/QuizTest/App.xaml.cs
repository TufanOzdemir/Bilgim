using System;
using System.Collections.Generic;
using QuizTest.Constant;
using QuizTest.Interface;
using QuizTest.Services;
using QuizTest.Views;
using Xamarin.Forms;

namespace QuizTest
{
    public partial class App : Application
    {
        IAudio _audio;
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

        public void PlaySound(int SoundName)
        {
            _audio = DependencyService.Get<IAudio>();
            _audio.PlayAudio(SoundName);
        }
        public void StopSound()
        {
            _audio.StopAudio();
        }
        private void FirstInitialize()
        {
            //Easy Questions
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Ankara Hangi Savaş Sırasında Başkent Olmuştur?",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Çanakkale",IsCorrect = false},
                    new Models.Answer(){Description = "Mohaç",IsCorrect = false},
                    new Models.Answer(){Description = "Trablusgarp",IsCorrect = true},
                    new Models.Answer(){Description = "Mısır Fethi",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Türkiye'nin ilk Cumhurbaşkanı kimdir? ",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Mustafa Kemal Atatürk",IsCorrect = true},
                    new Models.Answer(){Description = "Kanuni Sultan Süleyman",IsCorrect = false},
                    new Models.Answer(){Description = "Mehmed Vahdettin",IsCorrect = false},
                    new Models.Answer(){Description = "İsmet İnönü",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "İlk atom bombası hangi kente atılmıştır?",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Hiroşima",IsCorrect = true},
                    new Models.Answer(){Description = "New York",IsCorrect = false},
                    new Models.Answer(){Description = "Paris",IsCorrect = false},
                    new Models.Answer(){Description = "İstanbul",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Bir yerleşim biriminin denizden yüksekliğine ne denir?",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Metre",IsCorrect = false},
                    new Models.Answer(){Description = "Kilometre",IsCorrect = false},
                    new Models.Answer(){Description = "Rakım",IsCorrect = true},
                    new Models.Answer(){Description = "Bakım",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Yazıyı bulan uygarlık hangisidir?",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Lidyalılar",IsCorrect = false},
                    new Models.Answer(){Description = "Sümerler",IsCorrect = true},
                    new Models.Answer(){Description = "Babilliler",IsCorrect = false},
                    new Models.Answer(){Description = "Türkler",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Parayı bulan ilk uygarlık hangisidir?",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Lidyalılar",IsCorrect = true},
                    new Models.Answer(){Description = "Sümerler",IsCorrect = false},
                    new Models.Answer(){Description = "Babilliler",IsCorrect = false},
                    new Models.Answer(){Description = "Türkler",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Türk tarihinin en ünlü mimarı kimdir?",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Zaha Hadid",IsCorrect = false},
                    new Models.Answer(){Description = "Mimar Sinan",IsCorrect = true},
                    new Models.Answer(){Description = "Mimar Hayreddin",IsCorrect = false},
                    new Models.Answer(){Description = "Necip Dinç",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = ":Türk Medeni Kanunu hangi ülkenin medeni kanunundan esinlenerek hazırlanmıştır?",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Almanya",IsCorrect = false},
                    new Models.Answer(){Description = "Danimarka",IsCorrect = false},
                    new Models.Answer(){Description = "Hollanda",IsCorrect = false},
                    new Models.Answer(){Description = "İsviçre",IsCorrect = true},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Hababam Sınıfı Filminde “İnek Şaban” karakterini canlandıran sanatçı kimdir?",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Halit Akçatepe",IsCorrect = false},
                    new Models.Answer(){Description = "Ediz Hun",IsCorrect = false},
                    new Models.Answer(){Description = "Kemal Sunal",IsCorrect = true},
                    new Models.Answer(){Description = "Tarık Akan ",IsCorrect = false},
                }
            });
            //25.soruda kaldın








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
