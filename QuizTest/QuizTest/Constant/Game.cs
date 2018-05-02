using QuizTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTest.Constant
{
    public class Game
    {
        public bool GameStatus { get; set; }
        public bool IsDoubleAnswerJokerUsed { get; set; }
        public bool IsPercent50JokerUsed { get; set; }
        public bool IsTimeOut { get; set; }
        public int CurrentQuestion { get; set; }
        public int Point { get; set; }

        public Game()
        {
            ClearGame();
        }

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

        public void GameOver()
        {
            ClearGame();
        }

        private void ClearGame()
        {
            GameStatus = false;
            IsDoubleAnswerJokerUsed = false;
            IsPercent50JokerUsed = false;
            IsTimeOut = false;
            CurrentQuestion = 0;
            Point = 0;
        }

    }
}
