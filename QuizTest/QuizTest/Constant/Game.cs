using QuizTest.Models;
using QuizTest.ViewModel;
using System.Collections.Generic;

namespace QuizTest.Constant
{
    public class Game
    {
        public Game()
        {
            QuestionsWithAnswers = new List<QuestionAnswerViewModel>();
        }

        public bool GameStatus { get; set; }
        public bool IsDoubleAnswerJokerUsed { get; set; }
        public bool IsPercent50JokerUsed { get; set; }
        public bool IsTimeOut { get; set; }
        public int CurrentQuestionNumber { get; set; }
        public List<QuestionAnswerViewModel> QuestionsWithAnswers { get; set; }
        public int Point { get; set; }

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
        
        private void ClearGame()
        {
            GameStatus = false;
            IsDoubleAnswerJokerUsed = false;
            IsPercent50JokerUsed = false;
            IsTimeOut = false;
            CurrentQuestionNumber = 0;
            QuestionsWithAnswers = null;
            Point = 0;
        }

    }
}
