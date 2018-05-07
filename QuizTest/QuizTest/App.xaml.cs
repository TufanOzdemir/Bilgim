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
            ClearDatabase();
            if (questionService.GetAll().Count == 0)
            {
                FirstInitialize();
            }
            MainPage = new MainPage(this);
        }

        private void FirstInitialize()
        {
            //Kolay Sorular
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
                    Description = "Türkiye'nin ilk Cumhurbaşkanı kimdir?",
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
                    Description = "Ilk yazıyı bulan uygarlık hangisidir?",
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
                    Description = "Parayı bulan ilk uygarlık hangisidir?",
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
                    Description = "Türk Medeni Kanunu hangi ülkenin medeni kanunundan esinlenerek hazırlanmıştır?",
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
                    new Models.Answer(){Description = "Tarık Akan ",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Bulgaristan’ın başkenti neresidir?",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Sofya",IsCorrect = true},
                    new Models.Answer(){Description = "Tahran",IsCorrect = false},
                    new Models.Answer(){Description = "Atina",IsCorrect = false},
                    new Models.Answer(){Description = "Erivan",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Devlet Su İşleri Genel Müdürlüğü hangi bakanlığımıza bağlıdır?",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Turizm Bakanlığı",IsCorrect = false},
                    new Models.Answer(){Description = "İçişleri Bakanlığı",IsCorrect = false},
                    new Models.Answer(){Description = "Çevre ve Orman Bakanlığı",IsCorrect = true},
                    new Models.Answer(){Description = "Bayındırlık ve İskan Bakanlığı",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Mimar Sinan’ın Ustalık Dönemi eseri sayılan Edirne’deki eserinin adı nedir?",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Selimiye",IsCorrect = true},
                    new Models.Answer(){Description = "Sultan Ahmet",IsCorrect = false},
                    new Models.Answer(){Description = "Aya Sofya",IsCorrect = false},
                    new Models.Answer(){Description = "Topkapı Sarayı",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Yeni Türk Lira’sındaki “Yeni” sözcüğü hangi tarihte atılmıştır?",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "01.01.2006",IsCorrect = false},
                    new Models.Answer(){Description = "01.01.2007",IsCorrect = false},
                    new Models.Answer(){Description = "12.12.2008",IsCorrect = false},
                    new Models.Answer(){Description = "01.01.2009",IsCorrect = true},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Dünya Ekonomik Forumu yıllık olağan toplantısı hangi ülkede yapılmıştır?",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "İngiltere",IsCorrect = false},
                    new Models.Answer(){Description = "Almanya",IsCorrect = false},
                    new Models.Answer(){Description = "İsviçre",IsCorrect = true},
                    new Models.Answer(){Description = "Fransa",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Turizm ve Kültür Bakanlığı ve UNESCO’nun işbirliği ile  2009 yılını ne yılı ilan edilmiştir?",
                    Difficult = Models.QuestionDifficult.Easy,
                    Time = 30
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Kaşgarlı Mahmut",IsCorrect = false},
                    new Models.Answer(){Description = "Mevlana Celaleddin Rumi",IsCorrect = false},
                    new Models.Answer(){Description = "Katip Çelebi- Hacı Bektaşi Veli",IsCorrect = true},
                    new Models.Answer(){Description = "Yahya Kemal Beyatlı",IsCorrect = false},
                }
            });

            //Orta Sorular
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

            //Zor Sorular
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
