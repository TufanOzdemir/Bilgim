using QuizTest.Models;
using QuizTest.ViewModel;
using System.Collections.Generic;

namespace QuizTest.Constant
{
    //Tüm oyunun yönetildiği sınıf
    public class Game
    {
        public Game()
        {
            QuestionsWithAnswers = new List<QuestionAnswerViewModel>();
        }

        #region Properties
        //Oyun durumu kontrol edildi.
        public bool GameStatus { get; set; }

        //Çift cevap jokeri kullanıldı.
        public bool IsDoubleAnswerJokerUsed { get; set; }

        //Yüzde 50 jokeri kullanıldı.
        public bool IsPercent50JokerUsed { get; set; }

        //Süre doldu mu öğrenildi.
        public bool IsTimeOut { get; set; }

        //Mevcut sorunun numarası alındı.
        public int CurrentQuestionNumber { get; set; }

        //Tüm sorular listelendi.
        public List<QuestionAnswerViewModel> QuestionsWithAnswers { get; set; }

        //Skor bilgisi verildi.
        public int Point { get; set; }

        //Oyun durduruldu.
        public bool IsGamePaused { get; set; }

        //Çift cevap jokeri kullanımda mı öğrenildi.
        public bool IsDoubleAnswerJokerUsing { get; set; }

        #endregion

        //Skor eklemesi soru zorluğuna göre yapıldı.
        public void ScoreAdd(QuestionDifficult questionDifficult)
        {
            if (questionDifficult == QuestionDifficult.Easy)
            {
                Point += 100;
            }
            else if (questionDifficult == QuestionDifficult.Medium)
            {
                Point += 500;
            }
            else if (questionDifficult == QuestionDifficult.Hard)
            {
                Point += 1000;
            }
        }

        //Mevcut işlem gören soru getirildi.
        public QuestionAnswerViewModel CurrentQuestionAnswerViewModel()
        {
            return QuestionsWithAnswers[CurrentQuestionNumber];
        }

        //Mevcut soru numarasına göre oyunun durumu düzenlendi.
        public void NextTour()
        {
            if (CurrentQuestionNumber == QuestionsWithAnswers.Count)
            {
                GameStatus = false;
            }
        }

        //Oyun nesnesi temizlendi.
        private void ClearGame()
        {
            GameStatus = false;
            IsDoubleAnswerJokerUsed = false;
            IsPercent50JokerUsed = false;
            IsDoubleAnswerJokerUsing = false;
            IsTimeOut = false;
            CurrentQuestionNumber = 0;
            QuestionsWithAnswers = null;
            Point = 0;
        }

    }
}
