using QuizTest.Constant;
using QuizTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuizTest.Services
{
    public class GameService
    {
        QuestionService _questionService;
        AnswerService _answerService;
        Game game;
        public GameService()
        {
            _questionService = new QuestionService();
            _answerService = new AnswerService();
        }

        public Game StartNewGame()
        {
            game = new Game();
            //Easy
            while (game.QuestionsWithAnswers.Count < 5)
            {

                Question question = _questionService.GetRandomQuestion(Models.QuestionDifficult.Easy);
                if (!game.QuestionsWithAnswers.Any(w => w.Question.ID == question.ID))
                {
                    List<Answer> answerList = _answerService.GetAnswerListByQuestionID(question.ID);
                    game.QuestionsWithAnswers.Add(new ViewModel.QuestionAnswerViewModel()
                    {
                        Question = question,
                        AnswerList = answerList
                        
                    });
                }
            }
            //Medium
            while(game.QuestionsWithAnswers.Count < 10)
            {
                Question question = _questionService.GetRandomQuestion(Models.QuestionDifficult.Medium);
                if (!game.QuestionsWithAnswers.Any(w => w.Question.ID == question.ID))
                {
                    List<Answer> answerList = _answerService.GetAnswerListByQuestionID(question.ID);
                    game.QuestionsWithAnswers.Add(new ViewModel.QuestionAnswerViewModel()
                    {
                        Question = question,
                        AnswerList = answerList

                    });
                }
            }
            //Hard
            while (game.QuestionsWithAnswers.Count < 15)
            {
                Question question = _questionService.GetRandomQuestion(Models.QuestionDifficult.Hard);
                if (!game.QuestionsWithAnswers.Any(w => w.Question.ID == question.ID))
                {
                    List<Answer> answerList = _answerService.GetAnswerListByQuestionID(question.ID);
                    game.QuestionsWithAnswers.Add(new ViewModel.QuestionAnswerViewModel()
                    {
                        Question = question,
                        AnswerList = answerList

                    });
                }
            }
            //Filling game properties for new game
            FillGameProperties(game);
            return game;
        }

        private void FillGameProperties(Game game)
        {
            game.CurrentQuestionNumber = 0;
            game.GameStatus = true;
            game.IsDoubleAnswerJokerUsed = false;
            game.IsPercent50JokerUsed = false;
            game.IsTimeOut = false;
            game.Point = 0;
        }

        public Game GameOver()
        {
            return StartNewGame();
        }

    }
}
