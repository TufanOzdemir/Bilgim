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
                    Description = "“Sinekli Bakkal” Romanının Yazarı Aşağıdakilerden Hangisidir?",
                    Difficult = Models.QuestionDifficult.Medium,
                    Time = 45
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Reşat Nuri Güntekin",IsCorrect = false},
                    new Models.Answer(){Description = "Halide Edip Adıvar",IsCorrect = true},
                    new Models.Answer(){Description = "Ziya Gökalp",IsCorrect = false},
                    new Models.Answer(){Description = "Ömer Seyfettin",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Tsunami Felaketinde En Fazla Zarar Gören Güney Asya Ülkesi Aşağıdakilerden Hangisidir?",
                    Difficult = Models.QuestionDifficult.Medium,
                    Time = 45
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Endonezya",IsCorrect = true},
                    new Models.Answer(){Description = "Srilanka",IsCorrect = false},
                    new Models.Answer(){Description = "Tayland",IsCorrect = false},
                    new Models.Answer(){Description = "Hindistan",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "2003 Yılında Euro Vizyon Şarkı Yarışmasında Ülkemizi Temsil Eden Ve Yarışmada Birinci Gelen Sanatçımız Kimdir?",
                    Difficult = Models.QuestionDifficult.Medium,
                    Time = 45
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Grup Athena",IsCorrect = false},
                    new Models.Answer(){Description = "Sertap Erener",IsCorrect = true},
                    new Models.Answer(){Description = "Şebnem Paker",IsCorrect = false},
                    new Models.Answer(){Description = "Ajda Pekkan",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Mustafa Kemal Atatürk’ün Nüfusa Kayıtlı Olduğu İl Hangisidir?",
                    Difficult = Models.QuestionDifficult.Medium,
                    Time = 45
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Bursa",IsCorrect = false},
                    new Models.Answer(){Description = "Ankara",IsCorrect = false},
                    new Models.Answer(){Description = "İstanbul",IsCorrect = false},
                    new Models.Answer(){Description = "Gaziantep",IsCorrect = true},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Aşağıdakilerden Hangisi Dünya Sağlık Örgütünün Kısaltılmış İsmidir?",
                    Difficult = Models.QuestionDifficult.Medium,
                    Time = 45
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Uhw",IsCorrect = false},
                    new Models.Answer(){Description = "Unıcef",IsCorrect = false},
                    new Models.Answer(){Description = "Who",IsCorrect = true},
                    new Models.Answer(){Description = "Nato",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Romen Rakamında Hangi Sayı Yoktur?",
                    Difficult = Models.QuestionDifficult.Medium,
                    Time = 45
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "0",IsCorrect = true},
                    new Models.Answer(){Description = "50",IsCorrect = false},
                    new Models.Answer(){Description = "100",IsCorrect = false},
                    new Models.Answer(){Description = "1000",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Bir Gün Kaç Saniyedir?",
                    Difficult = Models.QuestionDifficult.Medium,
                    Time = 45
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "86000",IsCorrect = false},
                    new Models.Answer(){Description = "88600",IsCorrect = false},
                    new Models.Answer(){Description = "86400",IsCorrect = true},
                    new Models.Answer(){Description = "84800",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "2010’da yapılacak olan Dünya Münazara Yarışması’na ev sahipliği yapacak olan ülke aşağıdakilerden hangisidir?",
                    Difficult = Models.QuestionDifficult.Medium,
                    Time = 45
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Almanya",IsCorrect = false},
                    new Models.Answer(){Description = "İngiltere",IsCorrect = false},
                    new Models.Answer(){Description = "Türkiye",IsCorrect = true},
                    new Models.Answer(){Description = "Yunanistan",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Avrupa Birliği'nin en fazla önemsediği,her alanda geleceğin teknolojisi olarak adlandırılan bilim dalının adı nedir ? ",
                    Difficult = Models.QuestionDifficult.Medium,
                    Time = 45
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Nükleer enerji",IsCorrect = false},
                    new Models.Answer(){Description = "Nanoteknoloji",IsCorrect = true},
                    new Models.Answer(){Description = "Güneş enerjisi",IsCorrect = false},
                    new Models.Answer(){Description = "Astronomi",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "UEFA Kupasını alan ilk Türk takımı hangisidir?",
                    Difficult = Models.QuestionDifficult.Medium,
                    Time = 45
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Fenerbahçe",IsCorrect = false},
                    new Models.Answer(){Description = "Trabzonspor",IsCorrect = false},
                    new Models.Answer(){Description = "Beşiktaş",IsCorrect = false},
                    new Models.Answer(){Description = "Galatasaray",IsCorrect = true},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Dünyanın ilk haritasını çizen ünlü Türk denizcisi kimdir?",
                    Difficult = Models.QuestionDifficult.Medium,
                    Time = 45
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Piri Reis",IsCorrect = true},
                    new Models.Answer(){Description = "Çaka Beyi",IsCorrect = false},
                    new Models.Answer(){Description = "Fatih Sultan Süleyman",IsCorrect = false},
                    new Models.Answer(){Description = "Picasso",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Tarihte Türk adıyla kurulan ilk Türk devleti hangisidir?",
                    Difficult = Models.QuestionDifficult.Medium,
                    Time = 45
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Hunlar",IsCorrect = false},
                    new Models.Answer(){Description = "Hazarlar",IsCorrect = false},
                    new Models.Answer(){Description = "Göktürkler",IsCorrect = true},
                    new Models.Answer(){Description = "Osmanlı Devleti",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Telefonun mucidi kimdir?",
                    Difficult = Models.QuestionDifficult.Medium,
                    Time = 45
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Graham Bell",IsCorrect = true},
                    new Models.Answer(){Description = "Erikson",IsCorrect = false},
                    new Models.Answer(){Description = "Eistein",IsCorrect = false},
                    new Models.Answer(){Description = "Freud",IsCorrect = false},
                }
            });


            //Zor Sorular
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "İlk özgün Türk tiyatro yapıtı olarak kabul edilen Şair Evlenmesi, hangi yazarın eseridir?",
                    Difficult = Models.QuestionDifficult.Hard,
                    Time = 60
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "İbrahim Şinasi ",IsCorrect = true},
                    new Models.Answer(){Description = "Namık Kemal ",IsCorrect = false},
                    new Models.Answer(){Description = "Ahmet Mihtah Efendi ",IsCorrect = false},
                    new Models.Answer(){Description = "Abdülhak Hamit ",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "'İncecikten bir kar yağar,tozar Elif Elif diye' dizeleriyle başlayan semaiyi söyleyen saz şairirmiz kimdir?",
                    Difficult = Models.QuestionDifficult.Hard,
                    Time = 60
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Yunus Emre",IsCorrect = false},
                    new Models.Answer(){Description = "Pir Sultan Abdal",IsCorrect = false},
                    new Models.Answer(){Description = "Karacaoğlan",IsCorrect = true},
                    new Models.Answer(){Description = "Köroğlu",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Devlet Denetleme Kurulu aşağıdakilerden hangisine bağlıdır?",
                    Difficult = Models.QuestionDifficult.Hard,
                    Time = 60
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "TBMM",IsCorrect = false},
                    new Models.Answer(){Description = "Başbakanlık",IsCorrect = false},
                    new Models.Answer(){Description = "Cumhurbaşkanlığı",IsCorrect = true},
                    new Models.Answer(){Description = "Maliye Bakanlığı",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Soğuk Savaş'ta hangi iki ülke birbiriyle mücadele etti?",
                    Difficult = Models.QuestionDifficult.Hard,
                    Time = 60
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Amerika-SSCB",IsCorrect = true},
                    new Models.Answer(){Description = "SSCB-Kanada",IsCorrect = false},
                    new Models.Answer(){Description = "Amerika-Almanya",IsCorrect = false},
                    new Models.Answer(){Description = "Japonya-Amerika",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Avrupa Parlamentosu hangi şehirde bulunuyor?",
                    Difficult = Models.QuestionDifficult.Hard,
                    Time = 60
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Münih ",IsCorrect = false},
                    new Models.Answer(){Description = "Zürih ",IsCorrect = false},
                    new Models.Answer(){Description = "Lyon ",IsCorrect = false},
                    new Models.Answer(){Description = "Strasburg ",IsCorrect = true},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "II.Dünya Savaşında en çok vatandaşı ölen ülke hangisidir?",
                    Difficult = Models.QuestionDifficult.Hard,
                    Time = 60
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "İngiltere",IsCorrect = false},
                    new Models.Answer(){Description = "Almanya",IsCorrect = false},
                    new Models.Answer(){Description = "Fransa",IsCorrect = false},
                    new Models.Answer(){Description = "Sovyetler Birliği",IsCorrect = true},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Olimpiyat bayrağındaki 5 halka neyi ifade eder?",
                    Difficult = Models.QuestionDifficult.Hard,
                    Time = 60
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "5 ülkeyi",IsCorrect = false},
                    new Models.Answer(){Description = "Avrupa Birliğini",IsCorrect = false},
                    new Models.Answer(){Description = "5 Kıtayı",IsCorrect = true},
                    new Models.Answer(){Description = "5 kurucuyu",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Havayı oluşturan iki temel madde nelerdir?",
                    Difficult = Models.QuestionDifficult.Hard,
                    Time = 60
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Oksijen-Nitrojen",IsCorrect = true},
                    new Models.Answer(){Description = "Oksijen-Azot",IsCorrect = false},
                    new Models.Answer(){Description = "Oksiyen-Karbondioksit",IsCorrect = false},
                    new Models.Answer(){Description = "Azot-Karbondioksit",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Röntgen ışınlarından hangi metal korunma sağlar?",
                    Difficult = Models.QuestionDifficult.Hard,
                    Time = 60
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Bakır ",IsCorrect = true},
                    new Models.Answer(){Description = "Bor ",IsCorrect = false},
                    new Models.Answer(){Description = "Molibdenit ",IsCorrect = false},
                    new Models.Answer(){Description = "Kurşun",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Yeniçeri Ocağı`nı kaldırıp yerine düzenli bir ordu kuran Osmanlı padişahı kimdir?",
                    Difficult = Models.QuestionDifficult.Hard,
                    Time = 60
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "II.Mahmud",IsCorrect = true},
                    new Models.Answer(){Description = "I.Abdülhamit",IsCorrect = false},
                    new Models.Answer(){Description = "Sultan Reşat",IsCorrect = false},
                    new Models.Answer(){Description = "IV.Murad",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Türkiye İş Bankası hangi yıl kurulmuştur?",
                    Difficult = Models.QuestionDifficult.Hard,
                    Time = 60
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "1920 ",IsCorrect = false},
                    new Models.Answer(){Description = "1924 ",IsCorrect = true},
                    new Models.Answer(){Description = "1930 ",IsCorrect = false},
                    new Models.Answer(){Description = "1927",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Hong Kong`a 100 yıl boyunca sahip olup daha sonra Çin`e devreden ülke hangisidir?",
                    Difficult = Models.QuestionDifficult.Hard,
                    Time = 60
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Almanya",IsCorrect = false},
                    new Models.Answer(){Description = "Fransa",IsCorrect = false},
                    new Models.Answer(){Description = "ABD",IsCorrect = false},
                    new Models.Answer(){Description = "İngiltere",IsCorrect = true},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Varna Savaşı kaç yılında yapılmıştır?",
                    Difficult = Models.QuestionDifficult.Hard,
                    Time = 60
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "1244",IsCorrect = false},
                    new Models.Answer(){Description = "1444",IsCorrect = true},
                    new Models.Answer(){Description = "1440",IsCorrect = false},
                    new Models.Answer(){Description = "1144",IsCorrect = false},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Deniz kuvvetlerimizdeki Büyükamiral rütbesinin Kara Kuvvetlerimizdeki karşılığı nedir?",
                    Difficult = Models.QuestionDifficult.Hard,
                    Time = 60
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Tümgeneral ",IsCorrect = false},
                    new Models.Answer(){Description = "Orgeneral ",IsCorrect = false},
                    new Models.Answer(){Description = "Korgeneral ",IsCorrect = false},
                    new Models.Answer(){Description = "Mareşal",IsCorrect = true},
                }
            });
            questionService.Create(new ViewModel.QuestionAnswerViewModel()
            {
                Question = new Models.Question()
                {
                    Description = "Müslümanların Mekkelilere karşı kazandıkları ilk savaş aşağıdakilerden hangisidir?",
                    Difficult = Models.QuestionDifficult.Hard,
                    Time = 60
                },
                AnswerList = new List<Models.Answer>()
                {
                    new Models.Answer(){Description = "Uhud Savaşı",IsCorrect = false},
                    new Models.Answer(){Description = "Heyber Savaşı",IsCorrect = false},
                    new Models.Answer(){Description = "Hendek Savaşı",IsCorrect = false},
                    new Models.Answer(){Description = "Bedir Savaşı",IsCorrect = true},
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
            contentPage.RotateTo(360, 1000, Easing.SpringIn);
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
