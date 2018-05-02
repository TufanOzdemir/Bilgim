using QuizTest.Data;
using QuizTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizTest.Services
{
    public class AnswerService
    {
        DataContext<Answer> _dataContext;
        public AnswerService()
        {
            _dataContext = new DataContext<Answer>();
        }

        public List<Answer> GetAnswerListByQuestionID(int questionID)
        {
            List<Answer> answerList = _dataContext.GetAll().Where(w=>w.ID == questionID).ToList();
            return answerList;
        }
    }
}
