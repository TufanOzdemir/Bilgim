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
            List<Answer> answerList = _dataContext.GetAll().Where(w=>w.QuestionID == questionID).ToList();
            return answerList;
        }

        internal void CreateList(List<Answer> answerList)
        {
            try
            {
                foreach (var item in answerList)
                {
                    var k = _dataContext.Save(item);
                }
            }
            catch
            {
                
            }
        }

        public List<Answer> GetAll()
        {
            List<Answer> result;
            try
            {
                result = _dataContext.GetAll();
            }
            catch (Exception ex)
            {
                result = new List<Answer>();
            }
            return result;
        }

        internal void DeleteAll()
        {
            foreach (var item in _dataContext.GetAll())
            {
                _dataContext.Delete(item);
            }
        }
    }
}
